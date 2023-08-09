use crate::{
    api::endpoints::get::clients::get_all_clients,
     api::endpoints::get::practitioners::get_all_practitioners, 
     api::endpoints::get::clientsappointments::get_all_clients_appointments_for_timerange,
     api::endpoints::get::practitionerappointments::get_all_practitioner_appointments_for_timerange,
     api::endpoints::post::addpractitioner::post_practitioner,
     api::endpoints::put::updatepractitioner::put_practitioner,
     config::server::ServerConfig,
    database::connection::DatabaseConnection,
};
use actix_web::{web::Data, App, HttpServer};
use std::{
    error::Error,
    sync::{Arc, Mutex},
};



pub struct Server {
    server_config: ServerConfig,
}

impl Server {
    pub fn new(server_config: ServerConfig) -> Self {
        Self { server_config }
    }

    pub async fn run(
        &self,
        database_connection: Arc<Mutex<DatabaseConnection>>,
    ) -> Result<(), Box<dyn Error>> {
        HttpServer::new(move || {
            let data = Data::new(database_connection.clone());
            App::new().app_data(data)
            .service(get_all_clients)
            .service( get_all_practitioners)
            .service(get_all_clients_appointments_for_timerange)
            .service(get_all_practitioner_appointments_for_timerange)
            .service(post_practitioner)
            .service( put_practitioner)
        })
        .bind((self.server_config.host(), self.server_config.port()))?
        .run()
        .await?;

        Ok(())
    }
}
