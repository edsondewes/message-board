<template>
  <div v-if="messages.length">
    <Message 
      v-for="item in messages"
      v-bind="item" 
      :key="item.id" />
      
    <InfiniteLoading
      v-if="canInfiniteLoad"
      @infinite="infiniteHandler">
      <span slot="no-more">
        There is no more messages :(
      </span>
    </InfiniteLoading>
  </div>
  <EmptyListInfo v-else />
</template>

<script>
import InfiniteLoading from 'vue-infinite-loading';
import EmptyListInfo from './EmptyListInfo';
import Message from './Message';
import {
  EventBus,
  get as getMessages,
  MESSAGE_CREATED,
} from '../../apis/messageApi';

export default {
  name: 'MessageList',
  components: {
    EmptyListInfo,
    InfiniteLoading,
    Message,
  },
  props: {
    initialMessages: {
      type: Array,
      required: true,
    },
  },
  data() {
    return {
      //vue-infinite-loading does not work well on SSR
      //so we only load after mounting as a workaround
      canInfiniteLoad: false,
      messages: this.initialMessages,
    };
  },
  async asyncData() {
    const messages = await getMessages();
    return {
      initialMessages: messages,
    };
  },
  beforeDestroy() {
    EventBus.$off(MESSAGE_CREATED, this.loadMessages);
  },
  mounted() {
    EventBus.$on(MESSAGE_CREATED, this.loadMessages);
    this.canInfiniteLoad = true;
  },
  methods: {
    async infiniteHandler($state) {
      const lastMessageId = this.messages.length
        ? this.messages[this.messages.length - 1].id
        : undefined;

      const result = await getMessages(lastMessageId);
      $state.loaded();
      if (result.length) {
        this.messages = this.messages.concat(result);
      } else {
        $state.complete();
      }
    },
    async loadMessages() {
      this.messages = await getMessages();
    },
  },
};
</script>