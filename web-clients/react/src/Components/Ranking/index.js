import React from "react";
import PropTypes from "prop-types";
import EmptyRankingInfo from "./EmptyRankingInfo";
import RankingList from "./RankingList";
import { rankingContainer as rankingContainerClass } from "./_style.css";
import { getById as getMessage } from "../../apis/messageApi";
import { get as getRanking } from "../../apis/rankingApi";

function Ranking({ messages }) {
  return (
    <div className={rankingContainerClass}>
      <h2>Top messages</h2>
      {messages.length ? (
        <RankingList messages={messages} />
      ) : (
        <EmptyRankingInfo />
      )}
    </div>
  );
}

Ranking.getInitialProps = async function(optionName) {
  const ranking = await getRanking(optionName);

  const messageRequests = ranking.map(rankingItem =>
    getMessage(rankingItem.subjectId).then(message => ({
      count: rankingItem.count,
      id: message.id,
      text: message.text,
    })),
  );

  const messages = await Promise.all(messageRequests);
  return {
    messages,
  };
};

Ranking.propTypes = {
  messages: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      count: PropTypes.number.isRequired,
      text: PropTypes.string.isRequired,
    }),
  ).isRequired,
};

export default Ranking;
