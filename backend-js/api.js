var express = require("express");
var bodyParser = require("body-parser");
var cors = require("cors");
var app = express();
var router = require("./routes/router");

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(cors());
app.use("/api", router);

router.use((request, response, next) => {
  console.log("middleware");
  next();
});

var port = 3000;
app.listen(port);
console.log("CB API is runnning at " + port);
