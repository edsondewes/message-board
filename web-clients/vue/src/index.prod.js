const fs = require('fs');
const compression = require('compression');
const express = require('express');
const path = require('path');
const { createBundleRenderer } = require('vue-server-renderer');

function read(file) {
  return fs.readFileSync(file, 'utf-8');
}

function createRenderer() {
  const template = read('./templates/index.html');
  const clientManifest = JSON.parse(read('./vue-ssr-client-manifest.json'));
  const serverBundle = JSON.parse(read('./vue-ssr-server-bundle.json'));

  return createBundleRenderer(serverBundle, {
    clientManifest: clientManifest,
    inject: false,
    runInNewContext: false,
    template: template,
  });
}

const publicPath = '/';
const outputPath = path.join(__dirname, './static');

const app = express();
app.use(compression());
app.use(publicPath, express.static(outputPath));

const renderer = createRenderer();
app.get('*', async (req, res) => {
  renderer.renderToStream({}).pipe(res);
});

const port = process.argv.length > 2 ? process.argv[2] : 8081;
app.listen(port, function() {
  console.log(`Server running: http://localhost:${port}`);
});
