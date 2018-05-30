import React from "react";
import { emptyContainer, message as messageClass } from "./_style.css";

const EmptyListInfo = () => (
  <div className={`${messageClass} ${emptyContainer}`}>
    <p>
      <strong>We don&apos;t have any messages yet</strong>
    </p>
    <p>Be the first to spread your words!</p>
  </div>
);

export default EmptyListInfo;
