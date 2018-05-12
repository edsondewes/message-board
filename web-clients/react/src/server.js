import React from "react";
import ReactDOM from "react-dom/server";
import flushChunks from "webpack-flush-chunks";

import App from "./Components/App";

export default ({ clientStats }) => (req, res) => {
  const app = <App />;
  const appString = ReactDOM.renderToString(app);
  const { js, styles } = flushChunks(clientStats);

  res.render("index", {
    appString,
    js,
    styles,
  });
};
