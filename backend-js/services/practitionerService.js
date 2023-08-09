const repository = require("../repositories/practitionerRepository");
const Practitioner = require("../models/practitioner");
async function getAllPractitioners() {
  let listData = [];
  await repository.getPractitioners().then((data) => {
    listData = data[0];
  });
  let list = createPractitionersList(listData);
  return list;
}
function createPractitionersList(records) {
  let list = [];
  for (let row of records) {
    list.push(new Practitioner(row.id, row.displayName, row.discipline));
  }
  return list;
}
module.exports = {
  getPractitioners: getAllPractitioners,
};
