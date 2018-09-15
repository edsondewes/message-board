import React from "react";
import { Query } from "react-apollo";
import gql from "graphql-tag";

import EmptyRankingInfo from "./EmptyRankingInfo";
import RankingList from "./RankingList";
import { rankingContainer as rankingContainerClass } from "./_style.css";

const GET_RANKING = gql`
  query topLiked {
    ranking(optionName: "Like") {
      voteCount
      message {
        id
        text
      }
    }
  }
`;

function mapToModel(data) {
  return data.ranking.map(m => ({
    id: m.message.id,
    count: m.voteCount,
    text: m.message.text,
  }));
}

const Ranking = () => (
  <Query query={GET_RANKING}>
    {({ loading, data }) => {
      return (
        <div className={rankingContainerClass}>
          <h2>Top messages</h2>
          {loading || !data.ranking.length ? (
            <EmptyRankingInfo />
          ) : (
            <RankingList messages={mapToModel(data)} />
          )}
        </div>
      );
    }}
  </Query>
);

export default Ranking;
