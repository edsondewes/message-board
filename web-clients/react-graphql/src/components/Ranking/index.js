import React from "react";
import { useQuery } from "@apollo/react-hooks";
import { gql } from "apollo-boost";
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

function mapToModel(ranking) {
  return ranking.map(m => ({
    id: m.message.id,
    count: m.voteCount,
    text: m.message.text,
  }));
}

function Ranking() {
  const { data, loading } = useQuery(GET_RANKING);

  return (
    <div className={rankingContainerClass}>
      <h2>Top messages</h2>
      {loading || !data.ranking.length ? (
        <EmptyRankingInfo />
      ) : (
        <RankingList messages={mapToModel(data.ranking)} />
      )}
    </div>
  );
}

export default React.memo(Ranking);
