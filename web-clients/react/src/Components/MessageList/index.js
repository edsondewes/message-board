import React, { useEffect, useState } from "react";
import PropTypes from "prop-types";
import InfiniteScroll from "react-infinite-scroller";
import EmptyListInfo from "./EmptyListInfo";
import Message from "./Message";
import {
  MESSAGE_CREATED,
  eventBus,
  get as getMessages,
} from "../../apis/messageApi";

function MessageList({ messages }) {
  const [listState, setListState] = useState({
    messages,
    tryLoadMore: true,
  });

  useEffect(() => {
    eventBus.addListener(MESSAGE_CREATED, reload);

    return () => {
      eventBus.removeListener(MESSAGE_CREATED, reload);
    };
  }, []);

  async function loadNextPage() {
    const currentList = listState.messages;
    const lastMessageId = currentList.length
      ? listState.messages[currentList.length - 1].id
      : undefined;

    const nextPage = await getMessages(lastMessageId);
    setListState({
      messages: currentList.concat(nextPage),
      tryLoadMore: nextPage.length > 0,
    });
  }

  async function reload() {
    const messages = await getMessages();
    setListState({
      messages,
      tryLoadMore: true,
    });
  }

  if (listState.messages.length) {
    return (
      <InfiniteScroll hasMore={listState.tryLoadMore} loadMore={loadNextPage}>
        {listState.messages.map(m => (
          <Message key={m.id} id={m.id} created={m.created} text={m.text} />
        ))}
      </InfiniteScroll>
    );
  }

  return <EmptyListInfo />;
}

MessageList.getInitialProps = async function() {
  const messages = await getMessages();
  return {
    messages,
  };
};

MessageList.propTypes = {
  messages: PropTypes.arrayOf(
    PropTypes.shape({
      id: PropTypes.number.isRequired,
      created: PropTypes.string.isRequired,
      text: PropTypes.string.isRequired,
    }),
  ).isRequired,
};

export default MessageList;
