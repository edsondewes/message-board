const path = require("path");
const webpack = require("webpack");
const nodeExternals = require("webpack-node-externals");
const CopyWebpackPlugin = require("copy-webpack-plugin");

module.exports = {
  mode: "production",
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
    path: path.resolve(__dirname, "../dist"),
  },
  devtool: "source-map",
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
            loader: "css-loader",
            options: {
              localsConvention: "camelCaseOnly",
              modules: {
                mode: "local",
              },
              onlyLocals: true,
            },
          },
        ],
      },
    ],
  },
  plugins: [
    new webpack.DefinePlugin({
      __API_URL__: "process.env.INTERNAL_API_URL || process.env.PUBLIC_API_URL",
    }),
    new CopyWebpackPlugin([
      { from: "./src/index.prod.js", to: "./index.js" },
      { from: "./src/views", to: "./views" },
    ]),
  ],
};
