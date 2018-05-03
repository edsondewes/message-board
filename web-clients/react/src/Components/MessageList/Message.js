import React from "react";
import VoteContainer from "./VoteContainer";

const Message = ({ id, created, text }) => {
  const dt = new Date(created).toLocaleString();

  return (
    <article className="message">
      <p>{text}</p>
      <footer>
        <VoteContainer subjectId={id} />
        <time dateTime={dt}>{dt}</time>
      </footer>
    </article>
  );
};

export default Message;
