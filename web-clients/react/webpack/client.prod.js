const path = require("path");
const webpack = require("webpack");
const CopyWebpackPlugin = require("copy-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const OptimizeCSSAssetsPlugin = require("optimize-css-assets-webpack-plugin");
const StatsWebpackPlugin = require("stats-webpack-plugin");
const TerserJSPlugin = require("terser-webpack-plugin");
const { GenerateSW } = require("workbox-webpack-plugin");

module.exports = {
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
  optimization: {
    minimizer: [new TerserJSPlugin(), new OptimizeCSSAssetsPlugin()],
  },
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
              localsConvention: "camelCaseOnly",
              modules: {
                mode: "local",
              },
            },
          },
        ],
      },
    ],
  },
  plugins: [
    new webpack.DefinePlugin({
      __API_URL__: "window.__API_URL__",
    }),
    new MiniCssExtractPlugin({
      filename: "[name].[contenthash].css",
      chunkFilename: "[id].[contenthash].css",
    }),
    new CopyWebpackPlugin([{ from: "./public", to: "." }]),
    new StatsWebpackPlugin("../stats.json"),
    new GenerateSW({
      cacheId: "message-board-react",
      swDest: "service-worker.js",
      exclude: [/\.map$/, /\.LICENSE$/, /stats\.json$/],
      runtimeCaching: [
        {
          urlPattern: /^(http|https):\/\/\w+.\w+\/$/,
          handler: "NetworkFirst",
        },
        {
          urlPattern: /\/api\//,
          handler: "NetworkFirst",
        },
      ],
    }),
  ],
};
