use crate::database::connection::DatabaseConnection;

use actix_web::{
    get,
    web::{ Data, },
    Responder, Result, 
};
use tiberius::{ Uuid};
use std::{sync::{Arc, Mutex}, };
use serde::{Serialize, Deserialize};
use std::fmt::{self, Display, Formatter, Error};


struct Practitioner{
    practitioner_id: Option<Uuid>,
    display_name: Option<String>,
    discipline: Option<String>
}
impl Display for Practitioner {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "id : {:?} , name :{:?}, discipline: {:?}", self.practitioner_id, self.display_name, self.discipline)
    }
}
#[derive(Serialize, Deserialize, Debug)]
struct PractitionerModel{
    practitioner_id : Option<String>,
    display_name: Option<String>,
    discipline: Option<String>
}
impl From <Practitioner> for PractitionerModel{
    fn from(p: Practitioner)-> Self{
        let p_id = p.practitioner_id.map(|s| s.to_string()).to_owned();
        Self { practitioner_id: p_id, display_name: p.display_name , discipline: p.discipline}
    }
}
struct VecModel<PractitionerModel>(Vec<PractitionerModel>);
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
struct MyVec<Practitioner>(Vec<Practitioner>);
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



#[get("/api/practitioners")]
async fn get_all_practitioners(
    db: Data<Arc<Mutex<DatabaseConnection>>>,
) -> impl Responder{
    
    let sql = format!(
        "SELECT Id AS p_id, displayName AS p_name, discipline AS p_discipline  FROM Practitioners"
    );

    
    let mut guard = db.lock().expect("Mutex is broken.");

    let result = guard.simple_query(sql).await;
    match result {
        Ok(rows) => {
            let mut  vec: Vec<Practitioner> = Vec::new();
           let results = rows.into_results().await;
           for vec1 in results.iter(){
                for vec2 in vec1{
                    for row in vec2{
                        vec.push(Practitioner {
                            practitioner_id: row
                            .try_get::<Uuid, _>("p_id").as_ref().ok().and_then(|opt| opt.map(|s| s.to_owned())),
                            display_name: row
                            .try_get::<&str, _>("p_name").as_ref().ok().and_then(|opt| opt.map(|s| s.to_string())),
                            discipline : row
                            .try_get::<&str,_>("p_discipline").as_ref().ok().and_then(|opt| opt.map(|s| s.to_string()))
                        })

                    }
                    
                   

                  
            }
                
           }
           let mut vec_model : Vec<PractitionerModel> = Vec::new();
          
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