const webpack = require("webpack");
const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const { VueLoaderPlugin } = require("vue-loader");

module.exports = {
  mode: "development",
  entry: "./src/client.js",
  output: {
    path: path.resolve(__dirname, "./public"),
    publicPath: "/",
    filename: "bundle.js",
  },
  devtool: "eval-source-map",
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
        use: ["vue-style-loader", "css-loader"],
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
    new HtmlWebpackPlugin({
      template: "./src/templates/index.html",
    }),
  ],
  devServer: {
    contentBase: "./public",
    historyApiFallback: true,
    host: "0.0.0.0",
    port: 8091,
  },
};
