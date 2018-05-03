import React from "react";

const VoteButton = ({ children, onClick }) => (
  <button className="btn-vote" disabled={onClick ? false : true} onClick={onClick}>
    {children}
  </button>
);

export default VoteButton;
