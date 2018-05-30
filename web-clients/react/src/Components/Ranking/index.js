import React from "react";
import EmptyRankingInfo from "./EmptyRankingInfo";
import RankingList from "./RankingList";
import { rankingContainer as rankingContainerClass } from "./_style.css";
import { getById as getMessage } from "../../apis/messageApi";
import { get as getRanking } from "../../apis/rankingApi";

class Ranking extends React.Component {
  static async getInitialProps(optionName) {
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
  }

  render() {
    return (
      <div className={rankingContainerClass}>
        <h2>Top messages</h2>
        {this.props.messages.length ? (
          <RankingList messages={this.props.messages} />
        ) : (
          <EmptyRankingInfo />
        )}
      </div>
    );
  }
}

export default Ranking;
