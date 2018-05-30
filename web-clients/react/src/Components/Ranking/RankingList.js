import React from "react";
import { rankingList as rankingListClass } from "./_style.css";

const RankingList = ({ messages }) => (
  <ol className={rankingListClass}>
    {messages.map(message => (
      <li key={message.id}>
        <span>{message.count}</span>
        <p>{message.text}</p>
      </li>
    ))}
  </ol>
);

export default RankingList;
