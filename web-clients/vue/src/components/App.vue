<template>
  <div id="app">
    <Header
      @change-mobile-view="mobileView = $event"
      @toggle-theme="toggleTheme"
    />
    <FloatingPanel v-if="offline">
      <h1>Offline mode</h1>
      <p>You are working offline. Some features may not be available</p>
    </FloatingPanel>
    <div class="content-container">
      <main :class="['main-container', { 'mobile-visible': mobileView === 'messages' }]">
        <MessageForm />
        <MessageList v-bind="messageList" />
      </main>
      <aside :class="['right-container', { 'mobile-visible': mobileView === 'ranking' }]">
        <Ranking
          v-bind="ranking"
          option-name="like"
        />
      </aside>
    </div>
  </div>
</template>

<script>
import FloatingPanel from './FloatingPanel';
import Header from './Header';
import MessageForm from './MessageForm';
import MessageList from './MessageList';
import OfflineMixin from './OfflineMixin';
import Ranking from './Ranking';

export default {
  name: 'App',
  components: {
    FloatingPanel,
    Header,
    MessageForm,
    MessageList,
    Ranking,
  },
  mixins: [OfflineMixin],
  props: {
    messageList: {
      type: Object,
      required: true,
    },
    ranking: {
      type: Object,
      required: true,
    },
  },
  data() {
    return {
      mobileView: 'messages',
    };
  },
  async asyncData() {
    const [messageList, ranking] = await Promise.all([
      MessageList.asyncData(),
      Ranking.asyncData(),
    ]);

    return {
      messageList,
      ranking,
    };
  },
  methods: {
    toggleTheme() {
      const root = document.documentElement;
      const themeAttribute = 'data-theme';
      if (root.hasAttribute(themeAttribute)) {
        root.removeAttribute(themeAttribute);
      } else {
        root.setAttribute(themeAttribute, 'dark');
      }
    },
  },
};
</script>

<style src="./base.css"></style>
<style src="./light-theme.css"></style>
<style src="./dark-theme.css"></style>
<style scoped>
.content-container {
  display: grid;
  grid-gap: 1vw;
  grid-template-columns: repeat(4, 1fr);
  margin: 0 auto;
  max-width: 90%;
}

.main-container {
  grid-column: 1 / 4;
}

.right-container {
  grid-column: 4;
}

@media only screen and (max-width: 768px) {
  .content-container {
    display: block;
    max-width: 100%;
  }

  .main-container,
  .right-container {
    display: none;
    grid-column: unset;
  }

  .mobile-visible {
    display: block;
  }
}
</style>
