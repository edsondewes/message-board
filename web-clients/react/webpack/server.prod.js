const path = require("path");
const webpack = require("webpack");
const nodeExternals = require("webpack-node-externals");
const CopyWebpackPlugin = require("copy-webpack-plugin");

module.exports = env => {
  if (!env || !env.API_URL) {
    throw "Environment variable 'API_URL' is required";
  }

  return {
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
              loader: "css-loader/locals",
              options: {
                camelCase: "only",
                modules: true,
              },
            },
          ],
        },
      ],
    },
    plugins: [
      new webpack.DefinePlugin({
        __API_URL__: JSON.stringify(env.API_URL),
      }),
      new CopyWebpackPlugin([
        { from: "./src/index.prod.js", to: "./index.js" },
        { from: "./src/views", to: "./views" },
      ]),
    ],
  };
};
