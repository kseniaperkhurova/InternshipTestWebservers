mod api;
mod config;
mod database;

use crate::{
    api::server::Server, config::database::DatabaseConfig, config::server::ServerConfig,
    database::connection::Connection,
};
use std::{
    error::Error,
    sync::{Arc, Mutex},
};

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
    let database_config = DatabaseConfig::new();
    let connection = Connection::new(database_config.get()).await?;
    let wrapped_connection = Arc::new(Mutex::new(connection));
    let server = Server::new(ServerConfig::new());
    server.run(wrapped_connection.clone()).await?;

    Ok(())
}
