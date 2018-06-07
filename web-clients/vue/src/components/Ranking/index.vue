<template>
  <div class="ranking-container">
    <h2>Top messages</h2>
    <RankingList 
      v-if="messages.length" 
      :messages="messages" />
    <EmptyRankingInfo v-else />
  </div>
</template>

<script>
import EmptyRankingInfo from "./EmptyRankingInfo";
import RankingList from "./RankingList";
import { getById as getMessage } from "../../apis/messageApi";
import { get as getRanking } from "../../apis/rankingApi";

export default {
  name: 'Ranking',
  components: {
    EmptyRankingInfo,
    RankingList
  },
  props: {
    optionName: {
      type: String,
      required: true
    }
  },
  data() {
    return {
      messages: []
    };
  },
  async created() {
    const ranking = await getRanking(this.optionName);
    const messageRequests = ranking.map(rankingItem =>
      getMessage(rankingItem.subjectId).then(message => ({
        count: rankingItem.count,
        id: message.id,
        text: message.text,
      })),
    );

    const response = await Promise.all(messageRequests);
    this.messages = response;
  }
}
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