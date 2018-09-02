const path = require("path");
const webpack = require("webpack");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
  mode: "development",
  entry: path.join(__dirname, "../src/index.js"),
  output: {
    filename: "bundle.js",
    path: path.resolve(__dirname, "../public"),
    publicPath: "/",
  },
  devtool: "eval-source-map",
  module: {
    rules: [
      {
        enforce: "pre",
        test: /\.js$/,
        exclude: /node_modules/,
        loader: "eslint-loader",
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        loader: "babel-loader",
      },
      {
        test: /\.css$/,
        use: [
          MiniCssExtractPlugin.loader,
          {
            loader: "css-loader",
            options: {
              camelCase: "only",
              localIdentName: "[local]--[hash:base64:5]",
              modules: true,
            },
          },
        ],
      },
    ],
  },
  plugins: [
    new webpack.DefinePlugin({
      __GRAPHQL_URL__: JSON.stringify("http://localhost:8181/graphql"),
    }),
    new MiniCssExtractPlugin({
      filename: "[name].css",
      chunkFilename: "[id].css",
    }),
    new HtmlWebpackPlugin({
      template: path.resolve(__dirname, "../src/views/index.html"),
    }),
  ],
  devServer: {
    host: "0.0.0.0",
    port: 8092,
    contentBase: "./public",
    historyApiFallback: true,
  },
};
