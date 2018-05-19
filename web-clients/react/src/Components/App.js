import React from "react";
import "./_style.css";

import FloatingPanel from "./FloatingPanel";
import Header from "./Header";
import MessageForm from "./MessageForm";
import MessageList from "./MessageList";
import { OfflineProvider, OfflinePanel } from "./OfflineContext";
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
      <OfflineProvider>
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
        <OfflinePanel>
          <FloatingPanel>
            <h1>Offline mode</h1>
            <p>You are working offline. Some features may not be available</p>
          </FloatingPanel>
        </OfflinePanel>
      </OfflineProvider>
    );
  }
}

export default App;
