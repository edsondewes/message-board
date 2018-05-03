import React from "react";
import InfiniteScroll from "react-infinite-scroller";
import "./_style.css";

import Message from "./Message";
import { get as getMessages } from "../../apis/messageApi";

class MessageList extends React.Component {
  constructor(props) {
    super(props);

    this.loadNextPage = this.loadNextPage.bind(this);

    this.state = {
      messages: [],
    };
  }

  componentDidMount() {
    this.loadNextPage();
  }

  loadNextPage() {
    getMessages(this.state.from).then(result => {
      const lastRecord = result.length
        ? result[result.length - 1].id
        : undefined;

      this.setState(prevState => ({
        messages: prevState.messages.concat(result),
        from: lastRecord,
      }));
    });
  }

  render() {
    if (!this.state.messages) {
      return <div>Empty</div>;
    }

    return (
      <InfiniteScroll
        hasMore={this.state.from !== undefined}
        loadMore={this.loadNextPage}
      >
        {this.state.messages.map(m => (
          <Message key={m.id} id={m.id} created={m.created} text={m.text} />
        ))}
      </InfiniteScroll>
    );
  }
}

export default MessageList;
