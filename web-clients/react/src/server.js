import React from "react";
import ReactDOM from "react-dom/server";
import flushChunks from "webpack-flush-chunks";
import App from "./Components/App";

const apiUrl = process.env.PUBLIC_API_URL;
if (!apiUrl) {
  throw "Environment variable 'PUBLIC_API_URL' is required";
}

export default ({ clientStats }) => async (req, res, next) => {
  try {
    const initialProps = await App.getInitialProps();
    const app = <App {...initialProps} />;
    const appString = ReactDOM.renderToString(app);

    const { js, styles } = flushChunks(clientStats);

    res.render("index", {
      apiUrl: JSON.stringify(apiUrl),
      appString,
      js,
      state: JSON.stringify(initialProps),
      styles,
    });
  } catch (e) {
    next(e);
  }
};
