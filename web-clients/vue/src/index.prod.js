const compression = require("compression");
const express = require("express");

const app = express();
app.use(compression());
app.use(express.static("."));

app.get("*", function(req, res) {
  res.sendFile(`${__dirname}/index.html`);
});

const port = process.argv.length > 2 ? process.argv[2] : 8080;
app.listen(port, function() {
  console.log(`Server running: http://localhost:${port}`);
});
