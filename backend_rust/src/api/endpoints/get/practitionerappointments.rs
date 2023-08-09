use crate::database::connection::DatabaseConnection;

use actix_web::{
    get,
    web::{ Data, self, },
    Responder, Result, HttpRequest, 
};
use tiberius::{ Uuid};


use std::{sync::{Arc, Mutex}, };
use serde::{Serialize, Deserialize};
use std::fmt::{self, Display, Formatter, Error};

use chrono::{ NaiveDateTime, NaiveTime, };






struct Appointment{
    id: Option<Uuid>,
    date:  Option<NaiveDateTime>,
    start_time: Option<NaiveTime>,
    end_time :Option<NaiveTime>,
    name: Option<String>,
    discipline: Option<String>
}

impl Display for Appointment {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "id : {:?} , name :{:?}, date {:?}, startTime {:?}, endTime {:?}, discipline {:?}", self.id, self.name, self.date,  self.start_time, self.end_time, self.discipline)
    }
}
#[derive(Serialize, Deserialize, Debug)]
struct AppointmentModel{
    id:  Option<String>,
    date: Option<String>,
    start_time:Option<String>,
    end_time : Option<String>,
    name: Option<String>,
    discipline: Option<String>
}
impl From <Appointment> for AppointmentModel{
    fn from(a: Appointment)-> Self{
       
        let a_id = a.id.map(|s| s.to_string()).to_owned();
        let formatted_date = a.date.unwrap().format("%Y-%m-%d").to_string();
        let formatted_start_time = a.start_time.unwrap().format("%H:%M:%S").to_string();
        let formatted_end_time = a.end_time.unwrap().format("%H:%M:%S").to_string();
        let start_time_f = format!("{} {}", formatted_date, formatted_start_time);
        let end_time_f = format!("{} {}", formatted_date, formatted_end_time);
        Self { id: a_id, date: Some(formatted_date), start_time: Some(start_time_f), end_time:  Some(end_time_f), name: a.name, discipline: a.discipline }
    
    }
}
struct VecModel<AppointmentModel>(Vec<AppointmentModel>);
impl<T: Display> Display for VecModel<T> {
    fn fmt(&self, f: &mut Formatter) -> Result<(), Error> {
        write!(f, "[")?;
        for (i, v) in self.0.iter().enumerate() {
            if i != 0 { write!(f, "; ")?; }
            write!(f, "{}", v)?;
        }
        write!(f, "]")
    }
}
struct MyVec<Appointment>(Vec<Appointment>);
impl<T: Display> Display for MyVec<T> {
    fn fmt(&self, f: &mut Formatter) -> Result<(), Error> {
        write!(f, "[")?;
        for (i, v) in self.0.iter().enumerate() {
            if i != 0 { write!(f, ", ")?; }
            write!(f, "{}", v)?;
        }
        write!(f, "]")
    }
}
#[derive(Debug, Deserialize)]
pub struct Params {
    id: String,
    start_date: String,
    end_date: String
}


#[get("/api/appointments/practitioner/")]
async fn get_all_practitioner_appointments_for_timerange(
    req: HttpRequest,
    db: Data<Arc<Mutex<DatabaseConnection>>>,
) -> impl Responder{
    let  params = web::Query::<Params>::from_query(req.query_string()).unwrap();
   
    let sql = format!(
        "SELECT a.id AS a_id,
        CAST(a.Date AS varchar(255)) AS a_date,
        CAST(a.StartTime AS varchar(255)) AS a_start_time,
        CAST(a.EndTime AS varchar(255)) AS a_end_time,
	c.DisplayName AS c_name,
	p.Discipline AS p_discipline
    FROM AgendaItems a
    INNER JOIN Practitioners p ON a.PractitionerId = p.Id
    INNER JOIN Clients c  ON a.ClientId = c.Id
    WHERE a.PractitionerId = @P1 AND a.Date >=  @P2 AND a.Date <  @P3
    ORDER BY a.Date ASC;"
    );
   
    let mut guard = db.lock().expect("Mutex is broken.");

  
    let result = guard.query(sql, &[&params.id, &params.start_date, &params.end_date]).await;
   
    match result {
        Ok(rows) => {
            let mut  vec: Vec<Appointment> = Vec::new();
           let results = rows.into_results().await;
           for vec1 in results.iter(){
                for vec2 in vec1{
                    for row in vec2{
                        let date_value = row.try_get::<&str, _>("a_date");
                      let start_time_value = row.try_get::<&str, _>("a_start_time");
                      let end_date_value = row.try_get::<&str, _>("a_end_time");
                      let date_time = match date_value {
                        Ok(date) => {
                            let date_str2 = format!("{:?}", date);
                            let date_str1 = date_str2.split("\"").nth(1).unwrap();
                            let date_str = date_str1.split(".").next().unwrap();
                            Some(NaiveDateTime::parse_from_str(&date_str,"%Y-%m-%d %H:%M:%S").unwrap())
                        },
                        _ => None
                    };
                    let date_start_time = match start_time_value {
                        Ok(date) => {
                            let date_str2 = format!("{:?}", date);
                            let date_str1 = date_str2.split("\"").nth(1).unwrap();
                            let date_str = date_str1.split(".").next().unwrap();
                            Some(NaiveTime::parse_from_str(&date_str,"%H:%M:%S").unwrap())
                        },
                        _ => None
                    };
                    let date_end_time = match end_date_value {
                        Ok(date) => {
                            let date_str2 = format!("{:?}", date);
                            let date_str1 = date_str2.split("\"").nth(1).unwrap();
                            let date_str = date_str1.split(".").next().unwrap();
                            Some(NaiveTime::parse_from_str(&date_str,"%H:%M:%S").unwrap())
                        },
                        _ => None
                    };
                        vec.push(Appointment {
                            id: row
                                .try_get::<Uuid, _>("a_id").as_ref().ok().and_then(|opt| opt.map(|s| s.to_owned())),
                            date : date_time,
                            start_time : date_start_time,
                            end_time : date_end_time,
                            name : row
                            .try_get::<&str, _>("c_name").as_ref().ok().and_then(|opt| opt.map(|s| s.to_string())),
                            discipline : row
                            .try_get::<&str, _>("p_discipline").as_ref().ok().and_then(|opt| opt.map(|s| s.to_string())),
                        })

                    }
                    
                   

                  
            }
                
           }
          let mut vec_model : Vec<AppointmentModel> = Vec::new();
          
           for cl in vec{
            vec_model.push(cl.into());
            }
         
            let mut vec_json: Vec<String> = Vec::new();
            for cl in vec_model{
                vec_json.push(serde_json::to_string(&cl).unwrap())
            }
           let display_vec = MyVec(vec_json);
           
           format!("{}", display_vec)
           
          
           
        }
      
       Err(e) => format!("get_user endpoint failure: {e}"),
     
    }
                         
            
   
}