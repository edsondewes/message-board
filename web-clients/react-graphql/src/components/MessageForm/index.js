import React from "react";
import gql from "graphql-tag";
import { ApolloConsumer } from "react-apollo";
import style from "./_style.css";
import { eventBus, MESSAGE_CREATED } from "../../services/eventBus";

const ADD_MESSAGE = gql`
  mutation newMessages($message: MessageInput!) {
    createMessage(message: $message) {
      id
      created
      text
    }
  }
`;

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

  async onSubmit(event) {
    event.preventDefault();
    const { data } = await this.props.apolloClient.mutate({
      mutation: ADD_MESSAGE,
      variables: {
        message: {
          text: this.state.text,
        },
      },
    });

    this.resetForm();
    eventBus.emit(MESSAGE_CREATED, data.createMessage);
  }

  resetForm() {
    this.setState({ canSubmit: false, expanded: false, text: "" });
  }

  render() {
    return (
      <form
        onSubmit={this.onSubmit}
        className={`${style.messageForm} ${
          this.state.expanded ? style.expanded : ""
        }`}
      >
        <textarea
          aria-label="Write what's in your mind"
          onBlur={this.onBlur}
          onChange={this.onChange}
          onFocus={this.onFocus}
          value={this.state.text}
          placeholder="What's in your mind?"
          rows="1"
        />
        <div className={style.options}>
          <span>
            {this.state.text.length}/{TextLengthLimit}
          </span>
          <input
            {...(!this.state.canSubmit ? { disabled: true } : {})}
            className={style.btnSubmit}
            type="submit"
            value="Submit"
          />
        </div>
      </form>
    );
  }
}

const AppolloMessageForm = props => (
  <ApolloConsumer>
    {client => <MessageForm {...props} apolloClient={client} />}
  </ApolloConsumer>
);

export default AppolloMessageForm;
