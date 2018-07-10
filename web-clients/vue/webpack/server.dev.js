const nodeExternals = require('webpack-node-externals');
const path = require('path');
const webpack = require('webpack');
const { VueLoaderPlugin } = require('vue-loader');
const VueSSRServerPlugin = require('vue-server-renderer/server-plugin');

module.exports = {
  mode: 'development',
  name: 'server',
  target: 'node',
  externals: [nodeExternals()],
  entry: path.join(__dirname, '../src/entry-server.js'),
  output: {
    filename: 'app.server.js',
    libraryTarget: 'commonjs2',
    path: path.resolve(__dirname, '../public'),
  },
  devtool: false,
  resolve: {
    extensions: ['.js', '.vue'],
  },
  module: {
    rules: [
      {
        enforce: 'pre',
        test: /\.(js|vue)$/,
        exclude: /node_modules/,
        loader: 'eslint-loader',
      },
      {
        test: /\.vue$/,
        loader: 'vue-loader',
      },
      {
        test: /\.js$/,
        loader: 'babel-loader',
        exclude: /node_modules/,
      },
      {
        test: /\.css$/,
        use: ['vue-style-loader', 'css-loader'],
      },
    ],
  },
  plugins: [
    new VueLoaderPlugin(),
    new VueSSRServerPlugin(),
    new webpack.DefinePlugin({
      __API_URL__: JSON.stringify('http://localhost:9090/api'),
    }),
  ],
};
