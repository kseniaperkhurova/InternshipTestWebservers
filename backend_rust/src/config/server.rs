const HOST: &str = "127.0.0.1";
const PORT: u16 = 9501;

pub struct ServerConfig {
    host: &'static str,
    port: u16,
}

impl ServerConfig {
    pub fn new() -> Self {
        Self {
            host: HOST,
            port: PORT,
        }
    }

    pub fn host(&self) -> &'static str {
        self.host
    }

    pub fn port(&self) -> u16 {
        self.port
    }
}
