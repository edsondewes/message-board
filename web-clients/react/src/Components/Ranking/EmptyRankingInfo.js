import React from "react";
import { emptyContainer as emptyContainerClass } from "./_style.css";

const EmptyRankingInfo = () => (
  <div className={emptyContainerClass}>
    <p>Our ranking is still empty</p>
    <p>Vote for some messages and refresh the page to see the results</p>
  </div>
);

export default EmptyRankingInfo;
