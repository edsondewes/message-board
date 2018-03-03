import React from "react";
import MessageForm from "./MessageForm";
import MessageList from "./MessageList";

class App extends React.Component {
  render() {
    return (
      <>
        <MessageForm />
        <main>
          <MessageList />
        </main>
      </>
    );
  }
}

export default App;
