<template>
  <div id="app">
    <Header @change-mobile-view="mobileView = $event" />
    <div class="content-container">
      <main :class="['main-container', { 'mobile-visible': mobileView === 'messages' }]">
        <MessageForm />
        <MessageList />
      </main>
      <aside :class="['right-container', { 'mobile-visible': mobileView === 'ranking' }]">
        <Ranking option-name="Like" />
      </aside>
    </div>
  </div>
</template>

<script>
import Header from './Header'
import MessageForm from './MessageForm'
import MessageList from './MessageList'
import Ranking from './Ranking'

export default {
  name: 'App',
  components: {
    Header,
    MessageForm,
    MessageList,
    Ranking
  },
  data() {
    return {
      mobileView: 'messages'
    }
  }
}
</script>

<style src="./base.css"></style>
<style src="./light-theme.css"></style>
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
