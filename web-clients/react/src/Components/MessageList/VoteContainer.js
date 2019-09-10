import React, { useCallback, useContext, useEffect, useState } from "react";
import PropTypes from "prop-types";
import Octicon, { Thumbsdown, Thumbsup } from "@primer/octicons-react";
import { OfflineContext } from "../OfflineContext";
import { btnVote as btnVoteClass } from "./_style.css";
import { get as getVotes, post } from "../../apis/voteApi";

function VoteContainer({ subjectId }) {
  const offlineContext = useContext(OfflineContext);
  const [votes, setVotes] = useState({
    voted: false,
  });

  useEffect(() => {
    async function load() {
      const response = await getVotes(subjectId);
      setVotes(response);
    }

    load();
  }, [subjectId]);

  const submitVote = useCallback(
    async optionName => {
      const response = await post(subjectId, optionName);
      setVotes({ ...response, voted: true });
    },
    [subjectId],
  );

  const submitDislike = useCallback(() => submitVote("Dislike"), [submitVote]);
  const submitLike = useCallback(() => submitVote("Like"), [submitVote]);

  const voteEnabled = !votes.voted && offlineContext.online;

  return (
    <div>
      <button
        aria-label="Like this message"
        className={btnVoteClass}
        disabled={!voteEnabled}
        onClick={submitLike}
      >
        <Octicon icon={Thumbsup} /> {votes.like || 0}
      </button>
      <button
        aria-label="Dislike this message"
        className={btnVoteClass}
        disabled={!voteEnabled}
        onClick={submitDislike}
      >
        <Octicon icon={Thumbsdown} /> {votes.dislike || 0}
      </button>
    </div>
  );
}

VoteContainer.propTypes = {
  subjectId: PropTypes.number.isRequired,
};

export default VoteContainer;
