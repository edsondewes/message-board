import React from "react";

const Message = ({ created, text }) => (
  <article>
    <p>{text}</p>
    <footer>{created.toString()}</footer>
  </article>
);

export default Message;
