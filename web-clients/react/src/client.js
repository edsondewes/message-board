import React from "react";
import { hydrate } from "react-dom";
import App from "./Components/App";
import registerServiceWorker from "./registerServiceWorker";

const initialProps = window.__REACT_STATE__;
hydrate(<App {...initialProps} />, document.getElementById("root"));

registerServiceWorker();
