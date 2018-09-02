import React from "react";
import gql from "graphql-tag";
import { ApolloConsumer } from "react-apollo";
import InfiniteScroll from "react-infinite-scroller";

import EmptyListInfo from "./EmptyListInfo";
import Message from "./Message";

const GET_MESSAGES = gql`
  query paginatedList($from: Int) {
    messages(from: $from) {
      id
      created
      text
      votes {
        count
        optionName
      }
    }
  }
`;

class MessageList extends React.Component {
  constructor(props) {
    super(props);

    this.loadNextPage = this.loadNextPage.bind(this);

    this.state = {
      hasMore: true,
      messages: [],
    };
  }

  async componentDidMount() {
    const { data } = await this.props.apolloClient.query({
      query: GET_MESSAGES,
    });

    this.setState({ messages: data.messages });
  }

  async loadNextPage() {
    const lastMessageId = this.state.messages.length
      ? this.state.messages[this.state.messages.length - 1].id
      : undefined;

    const { data } = await this.props.apolloClient.query({
      query: GET_MESSAGES,
      variables: { from: lastMessageId },
    });

    this.setState(prevState => ({
      hasMore: data.messages.length > 0,
      messages: prevState.messages.concat(data.messages),
    }));
  }

  render() {
    if (this.state.messages.length) {
      return (
        <InfiniteScroll
          hasMore={this.state.hasMore}
          loadMore={this.loadNextPage}
        >
          {this.state.messages.map(m => (
            <Message key={m.id} id={m.id} created={m.created} text={m.text} />
          ))}
        </InfiniteScroll>
      );
    }

    return <EmptyListInfo />;
  }
}

const AppolloMessageList = props => (
  <ApolloConsumer>
    {client => <MessageList {...props} apolloClient={client} />}
  </ApolloConsumer>
);

export default AppolloMessageList;
