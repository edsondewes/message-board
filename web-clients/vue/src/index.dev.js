const fs = require('fs');
const path = require('path');
const express = require('express');
const { createBundleRenderer } = require('vue-server-renderer');

function read(fs, basedir, file) {
  return fs.readFileSync(path.resolve(basedir, file), 'utf-8');
}

const clientConfig = require('../webpack/client.dev');
const serverConfig = require('../webpack/server.dev');
const outputPath = clientConfig.output.path;
const publicPath = clientConfig.output.publicPath;

const template = read(fs, __dirname, './templates/index.html');
const multiCompiler = require('webpack')([clientConfig, serverConfig]);
const devMiddleware = require('webpack-dev-middleware')(multiCompiler, {
  publicPath: publicPath,
});

let renderer;
multiCompiler.hooks.done.tap('CustomBundleRenderer', stats => {
  const errors = stats.toJson().errors;
  if (errors.length) return;

  const clientManifest = JSON.parse(
    read(devMiddleware.fileSystem, outputPath, 'vue-ssr-client-manifest.json'),
  );
  const serverBundle = JSON.parse(
    read(devMiddleware.fileSystem, outputPath, 'vue-ssr-server-bundle.json'),
  );

  renderer = createBundleRenderer(serverBundle, {
    clientManifest: clientManifest,
    runInNewContext: false,
    template: template,
  });
});

const app = express();
app.use(publicPath, express.static(outputPath));
app.use(devMiddleware);
app.use(
  require('webpack-hot-middleware')(multiCompiler.compilers[0], {
    heartbeat: 5000,
  }),
);

app.get('*', async (req, res) => {
  renderer.renderToStream({}).pipe(res);
});

const port = process.argv.length > 2 ? process.argv[2] : 8091;
app.listen(port, function() {
  console.log(`Server running: http://localhost:${port}`);
});
