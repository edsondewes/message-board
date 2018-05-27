import React from "react";
import { btnVote as btnVoteClass } from "./_style.css";

const VoteButton = ({ children, enabled, onClick }) => (
  <button className={btnVoteClass} disabled={!enabled} onClick={onClick}>
    {children}
  </button>
);

export default VoteButton;
