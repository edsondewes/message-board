import React from "react";
import style from "./_style.css";

import Header from "./Header";
import MessageForm from "./MessageForm";
import MessageList from "./MessageList";
import Ranking from "./Ranking";

class App extends React.Component {
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

  toggleTheme() {
    const root = document.documentElement;
    const themeAttribute = "data-theme";
    if (root.hasAttribute(themeAttribute)) {
      root.removeAttribute(themeAttribute);
    } else {
      root.setAttribute(themeAttribute, "dark");
    }
  }

  render() {
    return (
      <>
        <Header
          changeMobileView={this.changeMobileView}
          toggleTheme={this.toggleTheme}
        />
        <div className={style.contentContainer}>
          <main
            className={this.getContainerClass(style.mainContainer, "messages")}
          >
            <MessageForm />
            <MessageList />
          </main>
          <aside
            className={this.getContainerClass(style.rightContainer, "ranking")}
          >
            <Ranking />
          </aside>
        </div>
      </>
    );
  }
}

export default App;
