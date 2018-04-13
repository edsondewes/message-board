import React from "react";

const VoteButton = ({ children, onClick }) => (
  <button disabled={onClick ? false : true} onClick={onClick}>
    {children}
  </button>
);

export default VoteButton;
