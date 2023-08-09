use tiberius::{AuthMethod, Config};

const HOST: &str = "127.0.0.1";
const PORT: u16 = 1433;
const DATABASE: &str = "casebased";
const USERNAME: &str = "sa";
const PASSWORD: &str = "xenia";

pub struct DatabaseConfig {
    tiberius_config: Config,
}

impl DatabaseConfig {
    pub fn new() -> Self {
        let mut database_config = Self {
            tiberius_config: Config::new(),
        };

        database_config.tiberius_config.host(HOST);
        database_config.tiberius_config.port(PORT);
        database_config.tiberius_config.database(DATABASE);
        database_config
            .tiberius_config
            .authentication(AuthMethod::sql_server(USERNAME, PASSWORD));
        database_config.tiberius_config.trust_cert();

        database_config
    }

    pub fn get(&self) -> Config {
        self.tiberius_config.clone()
    }
}
