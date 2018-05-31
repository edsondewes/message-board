const path = require("path");
const webpack = require("webpack");
const CopyWebpackPlugin = require("copy-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const StatsWebpackPlugin = require("stats-webpack-plugin");
const SWPrecacheWebpackPlugin = require("sw-precache-webpack-plugin");

module.exports = env => {
  if (!env || !env.API_URL) {
    throw "Environment variable 'API_URL' is required";
  }

  return {
    mode: "production",
    entry: {
      main: path.join(__dirname, "../src/client.js"),
    },
    output: {
      filename: "[name].[chunkhash].js",
      chunkFilename: "[name].[chunkhash].chunk.js",
      path: path.resolve(__dirname, "../dist/static"),
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
        {
          test: /\.css$/,
          use: [
            MiniCssExtractPlugin.loader,
            {
              loader: "css-loader",
              options: {
                camelCase: "only",
                minimize: true,
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
      new MiniCssExtractPlugin({
        filename: "[name].[contenthash].css",
        chunkFilename: "[id].[contenthash].css",
      }),
      new CopyWebpackPlugin([{ from: "./public", to: "." }]),
      new StatsWebpackPlugin("../stats.json"),
      new SWPrecacheWebpackPlugin({
        cacheId: "message-board-react",
        filename: "service-worker.js",
        minify: false,
        staticFileGlobsIgnorePatterns: [/\.map$/, /stats\.json$/],
        runtimeCaching: [
          {
            urlPattern: /^(http|https):\/\/\w+.\w+\/$/,
            handler: "networkFirst",
          },
          {
            urlPattern: /\/api\//,
            handler: "networkFirst",
          },
        ],
      }),
    ],
  };
};
