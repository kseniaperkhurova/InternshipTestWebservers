var config = require("../loaders/database");
const sql = require("mssql");
async function getAllPractitioners() {
  try {
    let pool = await sql.connect(config);
    let practitioners = await pool.request().query("SELECT id AS id, DisplayName AS displayName, Discipline AS discipline  from Practitioners");
    return practitioners.recordsets;
  } catch (error) {
    console.log(error);
  }
}
module.exports = {
  getPractitioners: getAllPractitioners,
};
