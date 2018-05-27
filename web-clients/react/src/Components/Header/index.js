import React from "react";
import style from "./_style.css";

const Header = ({ changeMobileView }) => (
  <header className={style.topBar}>
    <div className={style.headerContainer}>
      <h1>Message Board</h1>
      <button
        className={style.toggleView}
        onClick={changeMobileView("messages")}
      >
        Messages
      </button>
      <button
        className={style.toggleView}
        onClick={changeMobileView("ranking")}
      >
        Ranking
      </button>
    </div>
  </header>
);

export default Header;
