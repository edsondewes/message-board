import React, { useState } from "react";
import PropTypes from "prop-types";
import style from "./_style.css";

import FloatingPanel from "./FloatingPanel";
import Header from "./Header";
import MessageForm from "./MessageForm";
import MessageList from "./MessageList";
import { OfflineProvider, OfflinePanel } from "./OfflineContext";
import Ranking from "./Ranking";

function App({ messageList, ranking }) {
  const [mobileView, setMobileView] = useState("messages");

  function changeMobileView(viewName) {
    return () => {
      if (viewName !== mobileView) {
        setMobileView(viewName);
      }
    };
  }

  function getContainerClass(defaultClass, viewName) {
    return mobileView === viewName
      ? `${defaultClass} ${style.mobileVisible}`
      : defaultClass;
  }

  function toggleTheme() {
    const root = document.documentElement;
    const themeAttribute = "data-theme";
    if (root.hasAttribute(themeAttribute)) {
      root.removeAttribute(themeAttribute);
    } else {
      root.setAttribute(themeAttribute, "dark");
    }
  }

  return (
    <OfflineProvider>
      <Header changeMobileView={changeMobileView} toggleTheme={toggleTheme} />
      <OfflinePanel>
        <FloatingPanel>
          <h1>Offline mode</h1>
          <p>You are working offline. Some features may not be available</p>
        </FloatingPanel>
      </OfflinePanel>
      <div className={style.contentContainer}>
        <main className={getContainerClass(style.mainContainer, "messages")}>
          <MessageForm />
          <MessageList {...messageList} />
        </main>
        <aside className={getContainerClass(style.rightContainer, "ranking")}>
          <Ranking {...ranking} />
        </aside>
      </div>
    </OfflineProvider>
  );
}

App.getInitialProps = async function() {
  const [messageList, ranking] = await Promise.all([
    MessageList.getInitialProps(),
    Ranking.getInitialProps("like"),
  ]);

  return {
    messageList,
    ranking,
  };
};

App.propTypes = {
  messageList: PropTypes.object.isRequired,
  ranking: PropTypes.object.isRequired,
};

export default App;
