const practitionerService = require("../services/practitionerService");

module.exports.getAllPractitioners = async function (req, res, next) {
  try {
    const status = 200;
    const list = await practitionerService.getPractitioners();
    res.status(status).json(list);
  } catch (err) {
    next(err);
  }
};
