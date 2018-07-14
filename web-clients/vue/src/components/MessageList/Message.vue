<template>
  <article class="message">
    <p>{{ text }}</p>
    <footer>
      <VoteContainer :subject-id="id" />
      <time :datetime="localeDate">{{ localeDate }}</time>
    </footer>
  </article>
</template>

<script>
import VoteContainer from './VoteContainer';

export default {
  name: 'Message',
  components: {
    VoteContainer,
  },
  props: {
    created: {
      type: String,
      required: true,
    },
    id: {
      type: Number,
      required: true,
    },
    text: {
      type: String,
      required: true,
    },
  },
  computed: {
    localeDate() {
      return new Date(this.created).toLocaleString('en-US');
    },
  },
};
</script>

<style scoped>
.message {
  background: var(--content-bg-color);
  border: 1px solid var(--border-color);
  margin-bottom: 1vh;
  padding: 2vh 1vw;
}

.message footer {
  align-items: flex-end;
  display: flex;
  justify-content: space-between;
}

.message p {
  font-size: 1rem;
  margin: 0 0 1.5vh;
}

.message time {
  color: var(--secondary-color);
}

.message button,
.message time {
  font-size: 0.8rem;
}
</style>