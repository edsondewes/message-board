import React, { useCallback, useContext, useEffect, useState } from "react";
import PropTypes from "prop-types";

const OfflineContext = React.createContext(null);

function OfflineProvider({ children }) {
  const [online, setOnline] = useState(
    typeof navigator !== "undefined" ? navigator.onLine : true,
  );

  const updateOnlineStatus = useCallback(() => {
    setOnline(navigator.onLine);
  }, []);

  useEffect(() => {
    window.addEventListener("online", updateOnlineStatus);
    window.addEventListener("offline", updateOnlineStatus);

    return () => {
      window.removeEventListener("online", updateOnlineStatus);
      window.removeEventListener("offline", updateOnlineStatus);
    };
  }, [updateOnlineStatus]);

  return (
    <OfflineContext.Provider value={{ online }}>
      {children}
    </OfflineContext.Provider>
  );
}

OfflineProvider.propTypes = {
  children: PropTypes.node.isRequired,
};

function OfflinePanel({ children }) {
  const context = useContext(OfflineContext);
  return context.online ? null : children;
}

OfflinePanel.propTypes = {
  children: PropTypes.node.isRequired,
};

export { OfflineContext, OfflinePanel, OfflineProvider };
