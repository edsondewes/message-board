import React from "react";
import TopMessage from "./TopMessage";
import { get as getRanking } from "./apis/rankingApi";

class TopMessageList extends React.Component {
  componentDidMount() {
    getRanking(this.props.optionName).then(response =>
      this.setState({
        messages: response,
      }),
    );
  }

  render() {
    if (!this.state) return <div>Loading...</div>;

    return (
      <div>
        {this.state.messages.map(message => (
          <TopMessage key={message.subjectId} messageId={message.subjectId} />
        ))}
      </div>
    );
  }
}

export default TopMessageList;
