import React from "react";
import style from "./_style.css";
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
      <div className={style.rankingContainer}>
        <h2>Top messages</h2>
        <ol className={style.rankingList}>
          {this.props.messages.map(message => (
            <li key={message.id}>
              <span>{message.count}</span>
              <p>{message.text}</p>
            </li>
          ))}
        </ol>
      </div>
    );
  }
}

export default Ranking;
