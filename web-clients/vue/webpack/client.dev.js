const path = require('path');
const webpack = require('webpack');
const { VueLoaderPlugin } = require('vue-loader');
const VueSSRClientPlugin = require('vue-server-renderer/client-plugin');

module.exports = {
  mode: 'development',
  name: 'client',
  entry: [
    'webpack-hot-middleware/client',
    path.join(__dirname, '../src/entry-client.js'),
  ],
  output: {
    path: path.resolve(__dirname, '../public'),
    publicPath: '/',
    filename: '[name].js',
  },
  devtool: 'eval-source-map',
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
    new VueSSRClientPlugin(),
    new webpack.DefinePlugin({
      __API_URL__: 'window.__API_URL__',
    }),
    new webpack.HotModuleReplacementPlugin(),
    new webpack.NoEmitOnErrorsPlugin(),
  ],
};
