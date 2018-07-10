const nodeExternals = require('webpack-node-externals');
const path = require('path');
const webpack = require('webpack');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const { VueLoaderPlugin } = require('vue-loader');
const VueSSRServerPlugin = require('vue-server-renderer/server-plugin');

module.exports = {
  mode: 'production',
  target: 'node',
  externals: [nodeExternals()],
  entry: path.join(__dirname, '../src/entry-server.js'),
  output: {
    filename: 'app.server.js',
    libraryTarget: 'commonjs2',
    path: path.resolve(__dirname, '../dist'),
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
        use: ['css-loader/locals'],
      },
    ],
  },
  plugins: [
    new VueLoaderPlugin(),
    new VueSSRServerPlugin(),
    new webpack.DefinePlugin({
      __API_URL__: JSON.stringify('http://localhost:9090/api'),
    }),
    new CopyWebpackPlugin([
      { from: './src/index.prod.js', to: './index.js' },
      { from: './src/templates', to: './templates' },
    ]),
  ],
};
