use crate::database::connection::DatabaseConnection;

use actix_web::{
    post,
    web::{ Data, Json},
    Responder
};
use uuid::Uuid;
use std::{sync::{Arc, Mutex}, };
use serde::{ Deserialize};

#[derive(Deserialize)]
struct Params{
    display_name : String,
    discipline : String
}
trait StringOrU32 {
    fn is_string(&self) -> bool;
}

impl StringOrU32 for String {
    fn is_string(&self) -> bool {
        true
    }
}

impl StringOrU32 for u32 {
    fn is_string(&self) -> bool {
        false
    }
}

#[post("/post/practitioner/")]
async fn post_practitioner(
    db: Data<Arc<Mutex<DatabaseConnection>>>,
    request: Json<Params>
) -> impl Responder{
  
   if !request.display_name.is_string() || !request.discipline.is_string() {
        
   }  
   //let disciplines = vec!["Psycholoog(PS)", "Psycholoog(LV)", "Psycholoog(CGT)", "Fysiotherapeut", "Regiebehandelaar"];
//    let request_discipline = String::from(request.discipline) as String;
//    if !disciplines.contains(request_discipline.to_owned().to_string()){

//    }
    let id = Uuid::new_v4();
    let sql_post_practitioner = format!(
        "INSERT INTO Practitioners (Id, DisplayName, Discipline) VALUES (@P1, @P2, @P3)"
    );
    let mut guard = db.lock().expect("Mutex is broken.");
    let result = guard.query(sql_post_practitioner, &[&id, &request.display_name, &request.discipline]).await;
    match result {
        Ok(_) => {
            format!("Id of new practitioner {:?}", id)
        }
        Err(e) => format!("post practitioner endpoint failure: {e}"),
    }        
            
   
}