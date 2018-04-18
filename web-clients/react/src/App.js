import React from "react";
import MessageForm from "./MessageForm";
import MessageList from "./MessageList";
import TopMessageList from "./TopMessageList";

class App extends React.Component {
  render() {
    return (
      <>
        <MessageForm />
        <main>
          <MessageList />
        </main>
        <aside>
          <TopMessageList optionName="Like" />
        </aside>
      </>
    );
  }
}

export default App;
