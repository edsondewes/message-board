const webpack = require("webpack");
const path = require("path");
const CopyWebpackPlugin = require("copy-webpack-plugin");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const { VueLoaderPlugin } = require("vue-loader");

module.exports = {
  mode: "production",
  entry: "./src/client.js",
  output: {
    filename: "[name].[chunkhash].js",
    chunkFilename: "[name].[chunkhash].chunk.js",
    path: path.resolve(__dirname, "../dist"),
    publicPath: "/",
  },
  devtool: "source-map",
  resolve: {
    alias: {
      vue$: "vue/dist/vue.esm.js",
    },
    extensions: [".js", ".vue"],
  },
  module: {
    rules: [
      {
        enforce: "pre",
        test: /\.(js|vue)$/,
        exclude: /node_modules/,
        loader: "eslint-loader",
      },
      {
        test: /\.css$/,
        use: [MiniCssExtractPlugin.loader, "css-loader"],
      },
      {
        test: /\.vue$/,
        loader: "vue-loader",
      },
      {
        test: /\.js$/,
        loader: "babel-loader",
        exclude: /node_modules/,
      },
    ],
  },
  plugins: [
    new VueLoaderPlugin(),
    new webpack.DefinePlugin({
      __API_URL__: JSON.stringify("http://localhost:9090/api"),
    }),
    new MiniCssExtractPlugin({
      filename: "[name].[contenthash].css",
      chunkFilename: "[id].[contenthash].css",
    }),
    new CopyWebpackPlugin([
      { from: "./src/index.prod.js", to: "./index.js" },
      { from: "./public", to: "." },
    ]),
    new HtmlWebpackPlugin({
      template: "./src/templates/index.html",
    }),
  ],
};
