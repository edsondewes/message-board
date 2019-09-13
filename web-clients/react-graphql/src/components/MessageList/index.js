import React, { useCallback, useEffect } from "react";
import { useQuery } from "@apollo/react-hooks";
import { gql } from "apollo-boost";
import InfiniteScroll from "react-infinite-scroller";
import EmptyListInfo from "./EmptyListInfo";
import Message from "./Message";
import { eventBus, MESSAGE_CREATED } from "../../services/eventBus";

const GET_MESSAGES = gql`
  query paginatedList($from: Int) {
    messages(from: $from) {
      id
      created
      text
      votes(optionName: ["Like", "Dislike"]) {
        count
        optionName
      }
    }
  }
`;

function MessageList() {
  const {
    data: { messages, tryLoadMore } = {},
    fetchMore,
    loading,
    refetch,
  } = useQuery(GET_MESSAGES);

  const reload = useCallback(() => {
    refetch({ from: null });
  }, [refetch]);

  useEffect(() => {
    eventBus.addListener(MESSAGE_CREATED, reload);
    return () => eventBus.removeListener(MESSAGE_CREATED, reload);
  }, [reload]);

  if (loading || !messages.length) {
    return <EmptyListInfo />;
  }

  return (
    <InfiniteScroll
      hasMore={tryLoadMore || true}
      loadMore={() =>
        fetchMore({
          variables: {
            from: messages[messages.length - 1].id,
          },
          updateQuery: (prev, { fetchMoreResult }) => {
            if (!fetchMoreResult) {
              return prev;
            }

            return Object.assign({}, prev, {
              messages: [...prev.messages, ...fetchMoreResult.messages],
              tryLoadMore: fetchMoreResult.messages.length > 0,
            });
          },
        })
      }
    >
      {messages.map(m => (
        <Message key={m.id} {...m} />
      ))}
    </InfiniteScroll>
  );
}

export default React.memo(MessageList);
