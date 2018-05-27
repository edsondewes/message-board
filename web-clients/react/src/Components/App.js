import React from "react";
import style from "./_style.css";

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

  constructor(props) {
    super(props);

    this.changeMobileView = this.changeMobileView.bind(this);

    this.state = {
      mobileView: "messages",
    };
  }

  changeMobileView(viewName) {
    return () => {
      if (viewName !== this.state.mobileView) {
        this.setState({
          mobileView: viewName,
        });
      }
    };
  }

  getContainerClass(defaultClass, viewName) {
    return this.state.mobileView === viewName
      ? `${defaultClass} ${style.mobileVisible}`
      : defaultClass;
  }

  render() {
    return (
      <OfflineProvider>
        <Header changeMobileView={this.changeMobileView} />
        <OfflinePanel>
          <FloatingPanel>
            <h1>Offline mode</h1>
            <p>You are working offline. Some features may not be available</p>
          </FloatingPanel>
        </OfflinePanel>
        <div className={style.contentContainer}>
          <main
            className={this.getContainerClass(style.mainContainer, "messages")}
          >
            <MessageForm />
            <MessageList {...this.props.messageList} />
          </main>
          <aside
            className={this.getContainerClass(style.rightContainer, "ranking")}
          >
            <Ranking {...this.props.ranking} />
          </aside>
        </div>
      </OfflineProvider>
    );
  }
}

export default App;
