import React from "react";
import gql from "graphql-tag";
import { ApolloConsumer } from "react-apollo";
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

    this.loadNextPage = this.loadNextPage.bind(this);
    this.reload = this.reload.bind(this);

    this.state = {
      hasMore: true,
      messages: [],
    };
  }

  async componentDidMount() {
    eventBus.addListener(MESSAGE_CREATED, this.reload);

    const messages = await this.loadMessages();
    this.setState({ messages });
  }

  componentWillUnmount() {
    eventBus.removeListener(MESSAGE_CREATED, this.reload);
  }

  async loadMessages(from) {
    const { data } = await this.props.apolloClient.query({
      fetchPolicy: "network-only",
      query: GET_MESSAGES,
      variables: { from },
    });

    return data.messages;
  }

  async loadNextPage() {
    const lastMessageId = this.state.messages.length
      ? this.state.messages[this.state.messages.length - 1].id
      : undefined;

    const messages = await this.loadMessages(lastMessageId);
    this.setState(prevState => ({
      hasMore: messages.length > 0,
      messages: prevState.messages.concat(messages),
    }));
  }

  async reload() {
    const messages = await this.loadMessages();
    this.setState({
      hasMore: true,
      messages,
    });
  }

  render() {
    if (this.state.messages.length) {
      return (
        <InfiniteScroll
          hasMore={this.state.hasMore}
          loadMore={this.loadNextPage}
        >
          {this.state.messages.map(m => (
            <Message key={m.id} {...m} />
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
