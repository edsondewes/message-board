import React from "react";
import gql from "graphql-tag";
import { ApolloConsumer } from "react-apollo";
import Octicon from "../Octicon";
import { btnVote as btnVoteClass } from "./_style.css";

const DislikeOption = "Dislike";
const LikeOption = "Like";

const ADD_VOTE = gql`
  mutation newVote($vote: VoteInput!) {
    addVote(vote: $vote) {
      count
      optionName
    }
  }
`;

class VoteOptions extends React.Component {
  constructor(props) {
    super(props);

    this.submitDislike = this.submitVote.bind(this, DislikeOption);
    this.submitLike = this.submitVote.bind(this, LikeOption);

    this.state = {
      dislike: this.props.votes.find(v => v.optionName === DislikeOption).count,
      like: this.props.votes.find(v => v.optionName === LikeOption).count,
      voted: false,
    };
  }

  async submitVote(optionName) {
    const { data } = await this.props.apolloClient.mutate({
      mutation: ADD_VOTE,
      variables: {
        vote: {
          optionName: optionName,
          subjectId: this.props.subjectId.toString(),
        },
      },
    });

    const newState = { voted: true };
    const voteCount = data.addVote.count;
    switch (optionName) {
      case LikeOption:
        newState.like = voteCount;
        break;
      case DislikeOption:
        newState.dislike = voteCount;
        break;
      default:
        throw "Invalid vote option";
    }

    this.setState(newState);
  }

  render() {
    return (
      <div>
        <button
          aria-label="Like this message"
          className={btnVoteClass}
          disabled={this.state.voted}
          onClick={this.submitLike}
        >
          <Octicon ico="thumbsup" />
          {this.state.like}
        </button>
        <button
          aria-label="Dislike this message"
          className={btnVoteClass}
          disabled={this.state.voted}
          onClick={this.submitDislike}
        >
          <Octicon ico="thumbsdown" />
          {this.state.dislike}
        </button>
      </div>
    );
  }
}

const AppolloVoteOptions = props => (
  <ApolloConsumer>
    {client => <VoteOptions {...props} apolloClient={client} />}
  </ApolloConsumer>
);

export default AppolloVoteOptions;
