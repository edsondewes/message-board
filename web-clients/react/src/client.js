import React from "react";
import { hydrate } from "react-dom";
import App from "./Components/App";

const initialProps = window.__REACT_STATE__;
hydrate(<App {...initialProps} />, document.getElementById("root"));
