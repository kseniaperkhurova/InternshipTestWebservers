const clientService = require("../services/clientService");

module.exports.getAllClients = async function (req, res, next) {
  try {
    const status = 200;
    const list = await clientService.getClients();
    res.status(status).json(list);
  } catch (err) {
    next(err);
  }
};
