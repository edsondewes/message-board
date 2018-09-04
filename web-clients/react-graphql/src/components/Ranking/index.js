import React from "react";
import gql from "graphql-tag";
import { ApolloConsumer } from "react-apollo";
import EmptyRankingInfo from "./EmptyRankingInfo";
import RankingList from "./RankingList";
import { rankingContainer as rankingContainerClass } from "./_style.css";

const GET_RANKING = gql`
  query topLiked {
    ranking(optionName: "Like") {
      voteCount
      message {
        id
        text
      }
    }
  }
`;

class Ranking extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      messages: [],
    };
  }

  async componentDidMount() {
    const { data } = await this.props.apolloClient.query({
      query: GET_RANKING,
    });

    const messageWithVotes = data.ranking.map(m => ({
      id: m.message.id,
      count: m.voteCount,
      text: m.message.text,
    }));

    this.setState({ messages: messageWithVotes });
  }

  render() {
    return (
      <div className={rankingContainerClass}>
        <h2>Top messages</h2>
        {this.state.messages.length ? (
          <RankingList messages={this.state.messages} />
        ) : (
          <EmptyRankingInfo />
        )}
      </div>
    );
  }
}

const AppolloRanking = props => (
  <ApolloConsumer>
    {client => <Ranking {...props} apolloClient={client} />}
  </ApolloConsumer>
);

export default AppolloRanking;
