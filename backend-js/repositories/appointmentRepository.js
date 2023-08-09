var config = require("../loaders/database");
const sql = require("mssql");
const { v4: uuidv4 } = require("uuid");
const Appointment = require("../models/appointment");
async function getAllClientsAppointmentsForTimerange(id, startDate, endDate) {
  try {
    let pool = await sql.connect(config);
    let clientsAppointments = await pool
      .request()
      .input("clientId", sql.VarChar(50), id)
      .input("startDate", sql.VarChar(50), startDate)
      .input("endDate", sql.VarChar(50), endDate)
      .query(
        "SELECT a.id AS a_id, a.Date AS a_date,a.StartTime AS a_start_time,a.EndTime AS a_end_time,c.DisplayName AS c_name,p.Discipline AS p_discipline FROM AgendaItems a INNER JOIN Practitioners p ON a.PractitionerId = p.Id INNER JOIN Clients c  ON a.ClientId = c.Id WHERE c.Id = @clientId AND a.Date >= @startDate AND a.Date < @endDate  ORDER BY a.Date ASC;"
      );
    return clientsAppointments.recordsets;
  } catch (error) {
    console.log(error);
  }
}

async function getAllPractitionersAppointmentsForTimerange(id, startDate, endDate) {
  try {
    let pool = await sql.connect(config);
    let practitionersAppointments = await pool
      .request()
      .input("practitionerId", sql.VarChar(50), id)
      .input("startDate", sql.VarChar(50), startDate)
      .input("endDate", sql.VarChar(50), endDate)
      .query(
        "SELECT a.id AS a_id, a.Date AS a_date, a.StartTime AS a_start_time,a.EndTime AS a_end_time,c.DisplayName AS c_name,p.Discipline AS p_discipline FROM AgendaItems a INNER JOIN Practitioners p ON a.PractitionerId = p.Id INNER JOIN Clients c  ON a.ClientId = c.Id WHERE p.Id = @practitionerId AND a.Date >= @startDate AND a.Date < @endDate  ORDER BY a.Date ASC;"
      );
    return practitionersAppointments.recordsets;
  } catch (error) {
    console.log(error);
  }
}

module.exports = {
  getAllClientsAppointments: getAllClientsAppointmentsForTimerange,
  getAllPractitionersAppointments: getAllPractitionersAppointmentsForTimerange,
};
