import React from "react";
import PropTypes from "prop-types";
import VoteContainer from "./VoteContainer";
import { message as messageClass } from "./_style.css";

const Message = ({ id, created, text, votes }) => {
  const dt = new Date(created).toLocaleString("en-US");

  return (
    <article className={messageClass}>
      <p>{text}</p>
      <footer>
        <VoteContainer subjectId={id} votes={votes} />
        <time dateTime={dt}>{dt}</time>
      </footer>
    </article>
  );
};

Message.propTypes = {
  id: PropTypes.number.isRequired,
  created: PropTypes.string.isRequired,
  text: PropTypes.string.isRequired,
  votes: PropTypes.arrayOf(
    PropTypes.shape({
      count: PropTypes.number.isRequired,
      optionName: PropTypes.string.isRequired,
    }),
  ).isRequired,
};

export default React.memo(Message);
