<template>
  <div v-if="messages.length">
    <Message 
      v-for="item in messages"
      v-bind="item" 
      :key="item.id" />
      
    <InfiniteLoading @infinite="infiniteHandler">
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
import Message from './Message'
import { EventBus, get as getMessages, MESSAGE_CREATED } from "../../apis/messageApi";

export default {
  name: 'MessageList',
  components: {
    EmptyListInfo,
    InfiniteLoading,
    Message
  },
  data() {
    return {
      messages: []
    }
  },
  beforeDestroy() {
    EventBus.$off(MESSAGE_CREATED, this.loadMessages);
  },
  created () {
    EventBus.$on(MESSAGE_CREATED, this.loadMessages);
    this.loadMessages();
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
    }
  }, 
}
</script>