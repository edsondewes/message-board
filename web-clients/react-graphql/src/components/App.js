import React, { useCallback, useState } from "react";
import Header from "./Header";
import MessageForm from "./MessageForm";
import MessageList from "./MessageList";
import Ranking from "./Ranking";
import style from "./_style.css";

function App() {
  const [mobileView, setMobileView] = useState("messages");

  const toggleTheme = useCallback(() => {
    const root = document.documentElement;
    const themeAttribute = "data-theme";
    if (root.hasAttribute(themeAttribute)) {
      root.removeAttribute(themeAttribute);
    } else {
      root.setAttribute(themeAttribute, "dark");
    }
  }, []);

  function getContainerClass(defaultClass, viewName) {
    return mobileView === viewName
      ? `${defaultClass} ${style.mobileVisible}`
      : defaultClass;
  }

  return (
    <>
      <Header setMobileView={setMobileView} toggleTheme={toggleTheme} />
      <div className={style.contentContainer}>
        <main className={getContainerClass(style.mainContainer, "messages")}>
          <MessageForm />
          <MessageList />
        </main>
        <aside className={getContainerClass(style.rightContainer, "ranking")}>
          <Ranking />
        </aside>
      </div>
    </>
  );
}

export default App;
