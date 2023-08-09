const repository = require("../repositories/clientRepository");
const Client = require("../models/client");
async function getAllClients() {
  let listData = [];
  await repository.getClients().then((data) => {
    listData = data[0];
  });
  let list = createClientList(listData);
  return list;
}
function createClientList(records) {
  let list = [];
  for (let row of records) {
    list.push(new Client(row.id, row.displayName));
  }
  return list;
}
module.exports = {
  getClients: getAllClients,
};
