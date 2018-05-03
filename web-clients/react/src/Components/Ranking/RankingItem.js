import React from "react";

const RankingItem = ({ count, text }) => (
  <li>
    <span>{count}</span>
    <p>{text}</p>
  </li>
);

export default RankingItem;
