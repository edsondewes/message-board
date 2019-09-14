<template>
  <ol class="ranking-list">
    <li
      v-for="item in messages"
      :key="item.id"
      v-bind="item"
    >
      <span>{{ item.count }}</span>
      <p>{{ item.text }}</p>
    </li>
  </ol>
</template>

<script>
export default {
  name: 'RankingList',
  props: {
    messages: {
      type: Array,
      required: true,
    },
  },
};
</script>

<style scoped>
.ranking-list {
  font-size: 0.9rem;
  list-style: none;
  margin: 0;
  padding: 0;
}

.ranking-list li {
  align-items: flex-start;
  border-bottom: 1px solid var(--border-color);
  display: flex;
  margin-bottom: 1vh;
  padding-bottom: 1vh;
}

.ranking-list li:last-child {
  border: 0;
}

.ranking-list span {
  background: var(--secondary-color);
  border-radius: 10px;
  margin-right: 1vh;
  padding: 0.2vh 1vh;
}

.ranking-list p {
  margin: 0;
}
</style>