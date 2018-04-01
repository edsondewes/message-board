const path = require("path");
const webpack = require("webpack");

module.exports = {
  output: {
    filename: "bundle.js",
    path: path.resolve(__dirname, "public"),
    publicPath: "/",
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
    ],
  },
  plugins: [
    new webpack.DefinePlugin({
      __API_URL__: JSON.stringify("http://localhost:9090/api"),
    }),
  ],
  devServer: {
    contentBase: "./public",
    historyApiFallback: true,
    host: "0.0.0.0",
  },
};
