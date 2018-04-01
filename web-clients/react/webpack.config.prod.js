const path = require("path");
const webpack = require("webpack");
const CopyWebpackPlugin = require("copy-webpack-plugin");
const CleanWebpackPlugin = require("clean-webpack-plugin");

module.exports = env => {
  if (!env || !env.API_URL) {
    throw "Environment variable 'API_URL' is required";
  }

  return {
    output: {
      filename: "bundle.js",
      path: path.resolve(__dirname, "dist"),
      publicPath: "/",
    },
    devtool: "source-map",
    module: {
      rules: [
        {
          enforce: "pre",
          test: /\.(js|jsx)$/,
          exclude: /node_modules/,
          loader: "eslint-loader",
        },
        {
          test: /\.(js|jsx)$/,
          exclude: /node_modules/,
          loader: "babel-loader",
        },
      ],
    },
    plugins: [
      new webpack.DefinePlugin({
        __API_URL__: JSON.stringify(env.API_URL),
      }),
      new CleanWebpackPlugin(["dist"]),
      new CopyWebpackPlugin([{ from: "./public", to: "." }]),
    ],
  };
};
