import React from "react";
import InfiniteScroll from "react-infinite-scroller";
import Message from "./Message";
import {
  MESSAGE_CREATED,
  eventBus,
  get as getMessages,
} from "../../apis/messageApi";

class MessageList extends React.Component {
  static async getInitialProps() {
    const messages = await getMessages();
    return {
      messages,
    };
  }

  constructor(props) {
    super(props);

    this.loadNextPage = this.loadNextPage.bind(this);
    this.reload = this.reload.bind(this);

    this.state = {
      hasMore: true,
      messages: props.messages,
    };
  }

  componentDidMount() {
    eventBus.addListener(MESSAGE_CREATED, this.reload);
  }

  componentWillUnmount() {
    eventBus.removeListener(MESSAGE_CREATED, this.reload);
  }

  async loadNextPage() {
    const lastMessageId = this.state.messages.length
      ? this.state.messages[this.state.messages.length - 1].id
      : undefined;

    const messages = await getMessages(lastMessageId);
    this.setState(prevState => ({
      hasMore: messages.length > 0,
      messages: prevState.messages.concat(messages),
    }));
  }

  async reload() {
    const messages = await getMessages();
    this.setState({
      hasMore: true,
      messages,
    });
  }

  render() {
    return (
      <InfiniteScroll hasMore={this.state.hasMore} loadMore={this.loadNextPage}>
        {this.state.messages.map(m => (
          <Message key={m.id} id={m.id} created={m.created} text={m.text} />
        ))}
      </InfiniteScroll>
    );
  }
}

export default MessageList;
