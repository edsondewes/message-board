import React from "react";
import VoteButton from "./VoteButton";
import { get as getVotes, post } from "./apis/voteApi";

class VoteOptions extends React.Component {
  constructor(props) {
    super(props);
    this.submitDislike = this.submitVote.bind(this, "Dislike");
    this.submitLike = this.submitVote.bind(this, "Like");

    this.state = {};
  }

  componentDidMount() {
    getVotes(this.props.subjectId).then(response => {
      this.setState(response);
    });
  }

  removeEvents() {
    this.submitDislike = this.submitLike = null;
  }

  submitVote(optionName) {
    post(this.props.subjectId, optionName).then(response => {
      this.removeEvents();
      this.setState(response);
    });
  }

  render() {
    return (
      <>
        <VoteButton onClick={this.submitLike}>
          Like ({this.state.like || 0})
        </VoteButton>
        <VoteButton onClick={this.submitDislike}>
          Dislike ({this.state.dislike || 0})
        </VoteButton>
      </>
    );
  }
}

export default VoteOptions;
