const path = require("path");
const webpack = require("webpack");
const nodeExternals = require("webpack-node-externals");

module.exports = {
  mode: "development",
  name: "server",
  target: "node",
  externals: [
    nodeExternals({
      whitelist: ["webpack-flush-chunks"],
    }),
  ],
  entry: path.join(__dirname, "../src/server.js"),
  output: {
    filename: "app.server.js",
    libraryTarget: "commonjs2",
    path: path.resolve(__dirname, "../public"),
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
          {
            loader: "css-loader/locals",
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
      __API_URL__: JSON.stringify("http://localhost:9090/api"),
    }),
  ],
};
