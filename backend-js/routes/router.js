const express = require("express");
const router = express.Router();
const clientController = require("../controllers/clientController");
const practitionerController = require("../controllers/practitionerController");
const appointmentController = require("../controllers/appointmentController");
router.get("/clients", clientController.getAllClients);
router.get("/practitioners", practitionerController.getAllPractitioners);
router.get("/appointments/client", appointmentController.getAllClientsAppointments);
router.get("/appointments/practitioner", appointmentController.getAllPractitionersAppointments);

module.exports = router;
