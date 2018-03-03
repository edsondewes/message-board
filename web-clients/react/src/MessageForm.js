import React from "react";
import { post as postMessage } from "./apis/messageApi";

const TextLengthLimit = 250;

class MessageForm extends React.Component {
  constructor(props) {
    super(props);

    this.onChange = this.onChange.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      text: "",
    };
  }

  onChange(event) {
    if (event.target.value.length <= TextLengthLimit) {
      this.setState({ text: event.target.value });
    }
  }

  onSubmit(event) {
    postMessage({
      text: this.state.text,
    }).then(() => this.resetForm());

    event.preventDefault();
  }

  resetForm() {
    this.setState({ text: "" });
  }

  render() {
    return (
      <form onSubmit={this.onSubmit}>
        <textarea onChange={this.onChange} value={this.state.text} />
        <input type="submit" value="Submit" />
      </form>
    );
  }
}

export default MessageForm;
