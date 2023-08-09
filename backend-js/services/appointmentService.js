const repository = require("../repositories/appointmentRepository");
const Appointment = require("../models/appointment");
const { DateTime } = require("mssql");
async function getAllClientsAppointmentsForTimerange(id, startDate, endDate) {
  if (id == null || id == "undefined") {
    throw Error("id can not be null");
  }
  if (startDate == null || startDate == "undefined") {
    throw Error("startDate can not be null");
  }
  if (endDate == null || endDate == "undefined") {
    throw Error("endDate can not be null");
  }
  let listData = [];
  await repository.getAllClientsAppointments(id, startDate, endDate).then((data) => {
    listData = data[0];
  });
  let list = createAppointmentsList(listData);
  return list;
}

async function getAllPractitionersAppointmentsForTimerange(id, startDate, endDate) {
  if (id == null || id == "undefined") {
    throw Error("id can not be null");
  }
  if (startDate == null || startDate == "undefined") {
    throw Error("startDate can not be null");
  }
  if (endDate == null || endDate == "undefined") {
    throw Error("endDate can not be null");
  }
  let listData = [];
  await repository.getAllPractitionersAppointments(id, startDate, endDate).then((data) => {
    listData = data[0];
  });
  let list = createAppointmentsList(listData);
  return list;
}
function createAppointmentsList(records) {
  let list = [];
  for (let row of records) {
    let start_date = convertDate(row.a_date, row.a_start_time);
    let end_date = convertDate(row.a_date, row.a_end_time);
    list.push(new Appointment(row.a_id, start_date, end_date, row.c_name, row.p_discipline));
  }
  return list;
}
function convertDate(strDate, strTime) {
  let stringDate = String(strDate);
  let stringTime = String(strTime);
  let date = new Date(strDate);
  let time = new Date(strTime);
  date.setHours(time.getHours());
  date.setMinutes(time.getMinutes());
  return date;
}
module.exports = {
  getAllClientsAppointments: getAllClientsAppointmentsForTimerange,
  getAllPractitionersAppointments: getAllPractitionersAppointmentsForTimerange,
};
