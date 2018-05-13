import React from "react";
import "./_style.css";

import Header from "./Header";
import MessageForm from "./MessageForm";
import MessageList from "./MessageList";
import Ranking from "./Ranking";

class App extends React.Component {
  static async getInitialProps() {
    const [messageList, ranking] = await Promise.all([
      MessageList.getInitialProps(),
      Ranking.getInitialProps("Like"),
    ]);

    return {
      messageList,
      ranking,
    };
  }

  render() {
    return (
      <>
        <Header />
        <div className="content-container">
          <main className="main-container">
            <MessageForm />
            <MessageList {...this.props.messageList} />
          </main>
          <aside className="right-container">
            <Ranking {...this.props.ranking} />
          </aside>
        </div>
      </>
    );
  }
}

export default App;
