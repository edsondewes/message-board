import React from "react";
import PropTypes from "prop-types";
import style from "./_style.css";
import Octicon, { Paintcan, MarkGithub } from "@primer/octicons-react";

const Header = ({ changeMobileView, toggleTheme }) => (
  <header className={style.topBar}>
    <div className={style.headerContainer}>
      <h1>Message Board</h1>
      <button
        className={style.navButton}
        onClick={changeMobileView("messages")}
      >
        Messages
      </button>
      <button className={style.navButton} onClick={changeMobileView("ranking")}>
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

Header.propTypes = {
  changeMobileView: PropTypes.func.isRequired,
  toggleTheme: PropTypes.func.isRequired,
};

export default Header;
