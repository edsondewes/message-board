import React from "react";
import { post as postMessage } from "../../apis/messageApi";
import "./_style.css";

const TextLengthLimit = 250;

class MessageForm extends React.Component {
  constructor(props) {
    super(props);

    this.onBlur = this.onBlur.bind(this);
    this.onChange = this.onChange.bind(this);
    this.onFocus = this.onFocus.bind(this);
    this.onSubmit = this.onSubmit.bind(this);

    this.state = {
      canSubmit: false,
      expanded: false,
      text: "",
    };
  }

  onBlur() {
    if (this.state.text.length === 0) this.setState({ expanded: false });
  }

  onChange(event) {
    const currentLength = event.target.value.length;
    if (currentLength <= TextLengthLimit) {
      this.setState({
        canSubmit: currentLength > 0,
        text: event.target.value,
      });
    }
  }

  onFocus() {
    this.setState({ expanded: true });
  }

  onSubmit(event) {
    postMessage({
      text: this.state.text,
    }).then(() => this.resetForm());

    event.preventDefault();
  }

  resetForm() {
    this.setState({ canSubmit: false, expanded: false, text: "" });
  }

  render() {
    return (
      <form
        onSubmit={this.onSubmit}
        className={`message-form ${this.state.expanded ? "expanded" : ""}`}
      >
        <textarea
          onBlur={this.onBlur}
          onChange={this.onChange}
          onFocus={this.onFocus}
          value={this.state.text}
          placeholder="What's in your mind?"
        />
        <div className="options">
          <span>
            {this.state.text.length}/{TextLengthLimit}
          </span>
          <input
            {...(!this.state.canSubmit ? { disabled: true } : {})}
            className="btn-submit"
            type="submit"
            value="Submit"
          />
        </div>
      </form>
    );
  }
}

export default MessageForm;
