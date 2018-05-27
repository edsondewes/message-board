import React from "react";
import style from "./_style.css";

const FloatingPanel = ({ children }) => (
  <div className={style.floatingPanel}>{children}</div>
);

export default FloatingPanel;
