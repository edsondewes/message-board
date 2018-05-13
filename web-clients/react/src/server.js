import React from "react";
import ReactDOM from "react-dom/server";
import flushChunks from "webpack-flush-chunks";

import App from "./Components/App";

export default ({ clientStats }) => async (req, res, next) => {
  try {
    const initialProps = await App.getInitialProps();
    const app = <App {...initialProps} />;
    const appString = ReactDOM.renderToString(app);

    const { js, styles } = flushChunks(clientStats);

    res.render("index", {
      appString,
      state: JSON.stringify(initialProps),
      js,
      styles,
    });
  } catch (e) {
    next(e);
  }
};
