<template>
  <div class="ranking-container">
    <h2>Top messages</h2>
    <RankingList
      v-if="ranking.length"
      :messages="ranking"
    />
    <EmptyRankingInfo v-else />
  </div>
</template>

<script>
import EmptyRankingInfo from './EmptyRankingInfo';
import RankingList from './RankingList';
import { getById as getMessage } from '../../apis/messageApi';
import { get as getRanking } from '../../apis/rankingApi';

export default {
  name: 'Ranking',
  components: {
    EmptyRankingInfo,
    RankingList,
  },
  props: {
    ranking: {
      type: Array,
      required: true,
    },
  },
  async asyncData(optionName = 'Like') {
    const ranking = await getRanking(optionName);

    const messageRequests = ranking.map(rankingItem =>
      getMessage(rankingItem.subjectId).then(message => ({
        count: rankingItem.count,
        id: message.id,
        text: message.text,
      })),
    );

    const messages = await Promise.all(messageRequests);
    return {
      ranking: messages,
    };
  },
};
</script>

<style scoped>
.ranking-container {
  background: var(--content-bg-color);
  padding: 1vw;
}

.ranking-container h2 {
  margin: 0 0 2vh;
}
</style>