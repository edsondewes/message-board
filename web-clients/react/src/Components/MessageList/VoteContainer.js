import React from "react";
import octicons from "octicons";
import { OfflineConsumer } from "../OfflineContext";
import VoteButton from "./VoteButton";
import { get as getVotes, post } from "../../apis/voteApi";

class VoteOptions extends React.Component {
  constructor(props) {
    super(props);

    this.submitDislike = this.submitVote.bind(this, "Dislike");
    this.submitLike = this.submitVote.bind(this, "Like");

    this.state = {
      dislike: 0,
      like: 0,
      voted: false,
    };
  }

  componentDidMount() {
    getVotes(this.props.subjectId).then(response => {
      this.setState(response);
    });
  }

  submitVote(optionName) {
    post(this.props.subjectId, optionName).then(response => {
      this.setState({ ...response, voted: true });
    });
  }

  render() {
    return (
      <OfflineConsumer>
        {context => {
          const voteEnabled = !this.state.voted && context.online;
          return (
            <div>
              <VoteButton enabled={voteEnabled} onClick={this.submitLike}>
                <span
                  dangerouslySetInnerHTML={{
                    __html: octicons.thumbsup.toSVG(),
                  }}
                />
                {this.state.like}
              </VoteButton>
              <VoteButton enabled={voteEnabled} onClick={this.submitDislike}>
                <span
                  dangerouslySetInnerHTML={{
                    __html: octicons.thumbsdown.toSVG(),
                  }}
                />
                {this.state.dislike}
              </VoteButton>
            </div>
          );
        }}
      </OfflineConsumer>
    );
  }
}

export default VoteOptions;
