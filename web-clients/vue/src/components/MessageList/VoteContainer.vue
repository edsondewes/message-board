<template>
  <div>
    <button
      :disabled="voted || offline"
      aria-label="Like this message"
      class="btn-vote"
      @click="submiteVote('Like')"
    >
      <Octicon ico="thumbsup" /> {{ like }}
    </button>
    <button
      :disabled="voted || offline"
      aria-label="Dislike this message"
      class="btn-vote"
      @click="submiteVote('Dislike')"
    >
      <Octicon ico="thumbsdown" /> {{ dislike }}
    </button>
  </div>
</template>

<script>
import Octicon from '../Octicon';
import OfflineMixin from '../OfflineMixin';
import { get as getVotes, post } from '../../apis/voteApi';

export default {
  name: 'VoteContainer',
  components: {
    Octicon,
  },
  mixins: [OfflineMixin],
  props: {
    subjectId: {
      type: Number,
      required: true,
    },
  },
  data() {
    return {
      dislike: 0,
      like: 0,
      voted: false,
    };
  },
  async created() {
    const response = await getVotes(this.subjectId);
    this.updateVoteCount(response);
  },
  methods: {
    async submiteVote(optionName) {
      const response = await post(this.subjectId, optionName);
      this.updateVoteCount(response);
      this.voted = true;
    },
    updateVoteCount(data) {
      if (data.like) this.like = data.like;

      if (data.dislike) this.dislike = data.dislike;
    },
  },
};
</script>

<style scoped>
.btn-vote {
  background: transparent;
  border: 0;
  color: var(--secondary-color);
  cursor: pointer;
  margin-right: 1vw;
  padding: 0;
}

.btn-vote:disabled {
  color: var(--disabled-color);
  cursor: not-allowed;
}

.btn-vote span {
  margin-right: 0.5vw;
  font-size: 0.8rem;
}
</style>