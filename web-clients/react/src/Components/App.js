import React from "react";
import "./_style.css";

import Header from "./Header";
import MessageForm from "./MessageForm";
import MessageList from "./MessageList";
import Ranking from "./Ranking";

class App extends React.Component {
  render() {
    return (
      <>
        <Header />
        <div className="content-container">
          <main className="main-container">
            <MessageForm />
            <MessageList />
          </main>
          <aside className="right-container">
            <Ranking optionName="Like" />
          </aside>
        </div>
      </>
    );
  }
}

export default App;
