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


struct Client{
    client_id: Option<Uuid>,
    display_name: Option<String>
}

impl Display for Client {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "id : {:?} , name :{:?} ", self.client_id, self.display_name)
    }
}
#[derive(Serialize, Deserialize, Debug)]
struct ClientModel{
    client_id : Option<String>,
    display_name: Option<String>
}
impl From <Client> for ClientModel{
    fn from(c: Client)-> Self{
        let cl_id = c.client_id.map(|s| s.to_string()).to_owned();
        Self { client_id: cl_id, display_name: c.display_name }
    }
}
struct VecModel<ClientModel>(Vec<ClientModel>);
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
struct MyVec<Client>(Vec<Client>);
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



#[get("/api/clients")]
async fn get_all_clients(
    db: Data<Arc<Mutex<DatabaseConnection>>>,
) -> impl Responder{
    
    let sql = format!(
        "SELECT Id AS cl_id, displayName AS cl_name  FROM Clients"
    );

    
    let mut guard = db.lock().expect("Mutex is broken.");

    let result = guard.simple_query(sql).await;
    match result {
        Ok(rows) => {
            let mut  vec: Vec<Client> = Vec::new();
           let results = rows.into_results().await;
           for vec1 in results.iter(){
                for vec2 in vec1{
                    for row in vec2{
                        vec.push(Client {
                            client_id: row
                                .try_get::<Uuid, _>("cl_id").as_ref().ok().and_then(|opt| opt.map(|s| s.to_owned()))
                               ,
                            display_name: row
                            .try_get::<&str, _>("cl_name").as_ref().ok().and_then(|opt| opt.map(|s| s.to_string())),
                        })

                    }
                    
                   

                  
            }
                
           }
           let mut vec_model : Vec<ClientModel> = Vec::new();
          
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