import React from "react";
import PropTypes from "prop-types";
import Octicon, { Paintcan, MarkGithub } from "@primer/octicons-react";
import style from "./_style.css";

function Header({ setMobileView, toggleTheme }) {
  return (
    <header className={style.topBar}>
      <div className={style.headerContainer}>
        <h1>Message Board</h1>
        <button
          className={style.navButton}
          onClick={() => setMobileView("messages")}
        >
          Messages
        </button>
        <button
          className={style.navButton}
          onClick={() => setMobileView("ranking")}
        >
          Ranking
        </button>
        <button
          className={style.iconButton}
          onClick={toggleTheme}
          title="Toggle theme"
        >
          <Octicon icon={Paintcan} />
        </button>
        <a
          className={style.iconButton}
          href="https://github.com/edsondewes/message-board"
          title="Visit GitHub page"
        >
          <Octicon icon={MarkGithub} />
        </a>
      </div>
    </header>
  );
}

Header.propTypes = {
  setMobileView: PropTypes.func.isRequired,
  toggleTheme: PropTypes.func.isRequired,
};

export default React.memo(Header);
