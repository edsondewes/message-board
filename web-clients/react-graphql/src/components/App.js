import React from "react";
import style from "./_style.css";

import MessageList from "./MessageList";

class App extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className={style.contentContainer}>
        <main className={style.mainContainer}>
          <MessageList />
        </main>
        <aside className={style.rightContainer} />
      </div>
    );
  }
}

export default App;
