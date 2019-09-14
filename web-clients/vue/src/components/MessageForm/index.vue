<template>
  <form
    :class="['message-form', { expanded }]"
    @submit.prevent="submitMessage"
  >
    <textarea
      v-model="text"
      aria-label="Write what's in your mind"
      placeholder="What's in your mind?"
      rows="1"
      @focus="expandContainer"
      @blur="shrinkContainer"
      @input="truncateText"
    />
    <div class="options">
      <span>
        {{ text.length }} / {{ maxLength }}
      </span>
      <input
        :disabled="text.length === 0"
        class="btn-submit"
        type="submit"
        value="Submit"
      >
    </div>
  </form>
</template>

<script>
import { post as postMessage } from '../../apis/messageApi';

export default {
  name: 'MessageForm',
  props: {
    maxLength: {
      type: Number,
      default: 250,
    },
  },
  data() {
    return {
      expanded: false,
      text: '',
    };
  },
  methods: {
    expandContainer() {
      this.expanded = true;
    },
    shrinkContainer() {
      if (!this.text.length) this.expanded = false;
    },
    async submitMessage() {
      await postMessage({ text: this.text });
      this.expanded = false;
      this.text = '';
    },
    truncateText($event) {
      if ($event.target.value.length >= this.maxLength)
        this.text = $event.target.value.substr(0, this.maxLength);
    },
  },
};
</script>

<style scoped>
.btn-submit {
  background: var(--primary-bg-color);
  border: 1px solid var(--primary-border-color);
  color: var(--primary-color);
  font-size: 1rem;
  padding: 1vh 1vw;
  cursor: pointer;
}

.btn-submit:disabled {
  background: var(--disabled-bg-color);
  border-color: var(--disabled-border-color);
  color: var(--disabled-color);
  cursor: not-allowed;
}

.btn-submit:enabled:hover {
  background: var(--primary-hover-color);
}

.message-form {
  background: var(--form-bg-color);
  border-left: 1px solid var(--border-color);
  border-right: 1px solid var(--border-color);
  padding: 1vw;
}

.message-form textarea {
  background: var(--content-bg-color);
  border: 1px solid var(--border-color);
  border-radius: 5px;
  box-sizing: border-box;
  color: var(--main-color);
  display: block;
  font-size: 1.2rem;
  overflow: hidden;
  padding: 1.5vh;
  resize: none;
  width: 100%;
}

.message-form.expanded textarea {
  height: 15vh;
  margin-bottom: 2vh;
  overflow: auto;
}

.message-form.expanded .options {
  align-items: baseline;
  display: flex;
  justify-content: flex-end;
}

.options {
  display: none;
}

.options .btn-submit {
  margin-left: 1vw;
}
</style>