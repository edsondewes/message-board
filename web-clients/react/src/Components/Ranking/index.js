import React from "react";
import "./_style.css";
import RankingItem from "./RankingItem";
import { getById as getMessage } from "../../apis/messageApi";
import { get as getRanking } from "../../apis/rankingApi";

class Ranking extends React.Component {
  async componentDidMount() {
    const ranking = await getRanking(this.props.optionName);

    const messageRequests = ranking.map(rankingItem =>
      getMessage(rankingItem.subjectId).then(message => ({
        count: rankingItem.count,
        id: message.id,
        text: message.text,
      })),
    );

    const messages = await Promise.all(messageRequests);
    this.setState({
      messages: messages,
    });
  }

  render() {
    if (!this.state) return <div>Loading...</div>;

    return (
      <div className="ranking-container">
        <h2>Top messages</h2>
        <ol className="ranking-list">
          {this.state.messages.map(message => (
            <RankingItem
              key={message.id}
              text={message.text}
              count={message.count}
            />
          ))}
        </ol>
      </div>
    );
  }
}

export default Ranking;
