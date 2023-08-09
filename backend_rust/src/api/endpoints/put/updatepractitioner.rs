use crate::database::connection::DatabaseConnection;

use actix_web::{
    put,
    web::{ Data, Json},
    Responder
};
use std::{sync::{Arc, Mutex}, };
use serde::{ Deserialize};

#[derive(Deserialize)]
struct Params{
    id: String,
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

#[put("/update/practitioner/")]
async fn put_practitioner(
    db: Data<Arc<Mutex<DatabaseConnection>>>,
    request: Json<Params>
) -> impl Responder{
  
   if !request.display_name.is_string() || !request.discipline.is_string() || !request.id.is_string() {
        
   }  
   //let disciplines = vec!["Psycholoog(PS)", "Psycholoog(LV)", "Psycholoog(CGT)", "Fysiotherapeut", "Regiebehandelaar"];
//    let request_discipline = String::from(request.discipline) as String;
//    if !disciplines.contains(request_discipline.to_owned().to_string()){

//    }
    let sql_put_practitioner = format!(
        "UPDATE Practitioners
        SET DisplayName = @P1, Discipline = @P2
        WHERE Id = @P3"
    );
    let mut guard = db.lock().expect("Mutex is broken.");
    let result = guard.query(sql_put_practitioner, &[&request.display_name, &request.discipline, &request.id]).await;
    match result {
        Ok(_) => {
            format!("practitioner geupdated")
        }
        Err(e) => format!("post practitioner endpoint failure: {e}"),
    }        
            
   
}