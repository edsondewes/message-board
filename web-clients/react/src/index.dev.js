const express = require("express");
const path = require("path");

const clientConfig = require("../webpack/client.dev");
const serverConfig = require("../webpack/server.dev");

const multiCompiler = require("webpack")([clientConfig, serverConfig]);

const outputPath = clientConfig.output.path;
const publicPath = clientConfig.output.publicPath;

const app = express();
app.use(
  require("webpack-dev-middleware")(multiCompiler, {
    serverSideRender: true,
    publicPath: publicPath,
  }),
);

app.use(publicPath, express.static(outputPath));

app.use(
  require("webpack-hot-server-middleware")(multiCompiler, {
    serverRendererOptions: { outputPath },
  }),
);

app.set("views", path.join(__dirname, "./views"));
app.set("view engine", "ejs");

const port = process.argv.length > 2 ? process.argv[2] : 8090;
app.listen(port, function() {
  console.log(`Server running: http://localhost:${port}`);
});
