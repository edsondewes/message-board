import React from "react";

const DEFAULT_ONLINE_VALUE = true;

const OfflineContext = React.createContext({
  online: DEFAULT_ONLINE_VALUE,
});

const OfflineConsumer = OfflineContext.Consumer;

class OfflineProvider extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      online: DEFAULT_ONLINE_VALUE,
    };

    this.updateOnlineStatus = this.updateOnlineStatus.bind(this);
  }

  componentDidMount() {
    if (this.state.online !== navigator.onLine) {
      this.updateOnlineStatus();
    }

    window.addEventListener("online", this.updateOnlineStatus);
    window.addEventListener("offline", this.updateOnlineStatus);
  }

  componentWillUnmount() {
    window.removeEventListener("online", this.updateOnlineStatus);
    window.removeEventListener("offline", this.updateOnlineStatus);
  }

  updateOnlineStatus() {
    this.setState({
      online: navigator.onLine,
    });
  }

  render() {
    return (
      <OfflineContext.Provider value={this.state}>
        {this.props.children}
      </OfflineContext.Provider>
    );
  }
}

class OfflinePanel extends React.Component {
  render() {
    return (
      <OfflineConsumer>
        {context => !context.online && this.props.children}
      </OfflineConsumer>
    );
  }
}

export { OfflineConsumer, OfflinePanel, OfflineProvider };
