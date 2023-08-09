use std::error::Error;
use tiberius::{Client, Config};
use tokio::net::TcpStream;
use tokio_util::compat::{Compat, TokioAsyncWriteCompatExt};


pub type DatabaseConnection = Client<Compat<TcpStream>>;

pub struct Connection;
impl Connection {
    pub async fn new(config: Config) -> Result<DatabaseConnection, Box<dyn Error>> {
        let tcp = TcpStream::connect(config.get_addr()).await?;
        tcp.set_nodelay(true)?;

        let connection = match Client::connect(config, tcp.compat_write()).await {
          
            Ok(client) => client,
            Err(e) => Err(e)?,
        };

        Ok(connection)
    }
}
