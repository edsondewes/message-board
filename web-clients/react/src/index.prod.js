const compression = require("compression");
const express = require("express");
const path = require("path");

const app = express();
app.use(compression());

const clientStats = require("./stats.json");
const serverRender = require("./app.server.js").default;
const publicPath = "/";
const outputPath = path.join(__dirname, "./static");

app.use(publicPath, express.static(outputPath));
app.use(serverRender({ clientStats }));

app.set("views", path.join(__dirname, "views"));
app.set("view engine", "ejs");

const port = process.argv.length > 2 ? process.argv[2] : 8080;
app.listen(port, function() {
  console.log(`Server running: http://localhost:${port}`);
});
