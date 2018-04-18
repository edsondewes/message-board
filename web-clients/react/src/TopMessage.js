import React from "react";
import Message from "./Message";
import { getById as getMessage } from "./apis/messageApi";

class TopMessage extends React.Component {
  componentDidMount() {
    getMessage(this.props.messageId).then(response => {
      this.setState(response);
    });
  }

  render() {
    if (!this.state) return <div>Loading...</div>;

    return <Message created={this.state.created} text={this.state.text} />;
  }
}

export default TopMessage;
