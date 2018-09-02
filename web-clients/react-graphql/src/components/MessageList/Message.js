import React from "react";
import { message as messageClass } from "./_style.css";

const Message = ({ created, text }) => {
  const dt = new Date(created).toLocaleString("en-US");

  return (
    <article className={messageClass}>
      <p>{text}</p>
      <footer>
        <time dateTime={dt}>{dt}</time>
      </footer>
    </article>
  );
};

export default Message;
