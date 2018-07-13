const path = require('path');
const webpack = require('webpack');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const SWPrecacheWebpackPlugin = require('sw-precache-webpack-plugin');
const { VueLoaderPlugin } = require('vue-loader');
const VueSSRClientPlugin = require('vue-server-renderer/client-plugin');

module.exports = {
  mode: 'production',
  entry: path.join(__dirname, '../src/entry-client.js'),
  output: {
    filename: '[name].[chunkhash].js',
    chunkFilename: '[name].[chunkhash].chunk.js',
    path: path.resolve(__dirname, '../dist/static'),
    publicPath: '/',
  },
  devtool: 'source-map',
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
        use: [MiniCssExtractPlugin.loader, 'css-loader'],
      },
    ],
  },
  plugins: [
    new VueLoaderPlugin(),
    new VueSSRClientPlugin({
      filename: '../vue-ssr-client-manifest.json',
    }),
    new webpack.DefinePlugin({
      __API_URL__: 'window.__API_URL__',
    }),
    new MiniCssExtractPlugin({
      filename: '[name].[contenthash].css',
      chunkFilename: '[id].[contenthash].css',
    }),
    new CopyWebpackPlugin([{ from: './public', to: '.' }]),
    new SWPrecacheWebpackPlugin({
      cacheId: 'message-board-vue',
      filename: 'service-worker.js',
      minify: false,
      staticFileGlobsIgnorePatterns: [
        /\.map$/,
        /vue-ssr-client-manifest\.json$/,
      ],
      runtimeCaching: [
        {
          urlPattern: '/',
          handler: 'networkFirst',
        },
        {
          urlPattern: /\/api\//,
          handler: 'networkFirst',
        },
      ],
    }),
  ],
};
