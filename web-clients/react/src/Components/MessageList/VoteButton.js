import React from "react";

const VoteButton = ({ children, enabled, onClick }) => (
  <button className="btn-vote" disabled={!enabled} onClick={onClick}>
    {children}
  </button>
);

export default VoteButton;
