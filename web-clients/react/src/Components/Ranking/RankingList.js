import React from "react";
import PropTypes from "prop-types";
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

RankingList.propTypes = {
  messages: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      count: PropTypes.number.isRequired,
      text: PropTypes.string.isRequired,
    }),
  ).isRequired,
};

export default RankingList;
