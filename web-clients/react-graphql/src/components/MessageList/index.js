import React from "react";
import { Query } from "react-apollo";
import gql from "graphql-tag";
import InfiniteScroll from "react-infinite-scroller";

import EmptyListInfo from "./EmptyListInfo";
import Message from "./Message";
import { eventBus, MESSAGE_CREATED } from "../../services/eventBus";

const GET_MESSAGES = gql`
  query paginatedList($from: Int) {
    messages(from: $from) {
      id
      created
      text
      votes(optionName: ["Like", "Dislike"]) {
        count
        optionName
      }
    }
  }
`;

class MessageList extends React.Component {
  constructor(props) {
    super(props);
    this.reload = this.reload.bind(this);
  }

  async componentDidMount() {
    eventBus.addListener(MESSAGE_CREATED, this.reload);
  }

  componentWillUnmount() {
    eventBus.removeListener(MESSAGE_CREATED, this.reload);
  }

  reload() {
    this.forceUpdate();
  }

  render() {
    return (
      //network-only not working
      //maybe a bug? https://github.com/apollographql/react-apollo/issues/556
      <Query query={GET_MESSAGES} fetchPolicy="network-only">
        {({ loading, data: { messages }, fetchMore }) => {
          if (loading || !messages.length) return <EmptyListInfo />;

          return (
            <InfiniteScroll
              hasMore={messages.length > 0}
              loadMore={() =>
                fetchMore({
                  variables: {
                    from: messages[messages.length - 1].id,
                  },
                  updateQuery: (prev, { fetchMoreResult }) => {
                    if (!fetchMoreResult) return prev;
                    return Object.assign({}, prev, {
                      messages: [...prev.messages, ...fetchMoreResult.messages],
                    });
                  },
                })
              }
            >
              {messages.map(m => (
                <Message key={m.id} {...m} />
              ))}
            </InfiniteScroll>
          );
        }}
      </Query>
    );
  }
}

export default MessageList;
