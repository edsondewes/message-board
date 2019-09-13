import React, { useCallback, useMemo } from "react";
import PropTypes from "prop-types";
import { useMutation } from "@apollo/react-hooks";
import Octicon, { Thumbsdown, Thumbsup } from "@primer/octicons-react";
import { gql } from "apollo-boost";
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

function VoteContainer({ subjectId, votes }) {
  const [addVote, { data }] = useMutation(ADD_VOTE);
  const voteState = useMemo(() => {
    let dislikeCount = votes.find(v => v.optionName === DislikeOption).count;
    let likeCount = votes.find(v => v.optionName === LikeOption).count;
    let voted = false;

    // merge props data with the mutation
    if (data) {
      voted = true;
      switch (data.addVote.optionName) {
        case LikeOption:
          likeCount = data.addVote.count;
          break;
        case DislikeOption:
          dislikeCount = data.addVote.count;
          break;
        default:
          throw "Invalid vote option";
      }
    }

    return {
      dislikeCount,
      likeCount,
      voted,
    };
  }, [data, votes]);

  const submitVote = useCallback(
    async optionName => {
      await addVote({
        variables: {
          vote: {
            optionName,
            subjectId: subjectId.toString(),
          },
        },
      });
    },
    [addVote, subjectId],
  );

  const submitDislike = useCallback(
    async event => {
      event.preventDefault();
      await submitVote("Dislike");
    },
    [submitVote],
  );
  const submitLike = useCallback(() => submitVote("Like"), [submitVote]);

  return (
    <div>
      <button
        aria-label="Like this message"
        className={btnVoteClass}
        disabled={voteState.voted}
        onClick={submitLike}
      >
        <Octicon icon={Thumbsup} /> {voteState.likeCount}
      </button>
      <button
        aria-label="Dislike this message"
        className={btnVoteClass}
        disabled={voteState.voted}
        onClick={submitDislike}
      >
        <Octicon icon={Thumbsdown} /> {voteState.dislikeCount}
      </button>
    </div>
  );
}

VoteContainer.propTypes = {
  subjectId: PropTypes.number.isRequired,
  votes: PropTypes.arrayOf(
    PropTypes.shape({
      count: PropTypes.number.isRequired,
      optionName: PropTypes.string.isRequired,
    }),
  ).isRequired,
};

export default VoteContainer;
