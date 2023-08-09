var config = require("../loaders/database");
const sql = require("mssql");
async function getAllClients() {
  try {
    let pool = await sql.connect(config);
    let clients = await pool.request().query("SELECT id AS id, DisplayName AS displayName from Clients");
    return clients.recordsets;
  } catch (error) {
    console.log(error);
  }
}
module.exports = {
  getClients: getAllClients,
};
