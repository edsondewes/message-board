import React from "react";
import PropTypes from "prop-types";
import style from "./_style.css";

const FloatingPanel = ({ children }) => (
  <div className={style.floatingPanel}>{children}</div>
);

FloatingPanel.propTypes = {
  children: PropTypes.node.isRequired,
};

export default FloatingPanel;
