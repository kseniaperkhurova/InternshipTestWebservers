const appointmentService = require("../services/appointmentService");

module.exports.getAllClientsAppointments = async function (req, res, next) {
  try {
    const status = 200;
    let id = req.query.id;
    let startDate = req.query.startDate;
    let endDate = req.query.endDate;
    const list = await appointmentService.getAllClientsAppointments(id, startDate, endDate);
    res.status(status).json(list);
  } catch (err) {
    next(err);
  }
};

module.exports.getAllPractitionersAppointments = async function (req, res, next) {
  try {
    const status = 200;
    let id = req.query.id;
    let startDate = req.query.startDate;
    let endDate = req.query.endDate;
    const list = await appointmentService.getAllPractitionersAppointments(id, startDate, endDate);
    res.status(status).json(list);
  } catch (err) {
    next(err);
  }
};
