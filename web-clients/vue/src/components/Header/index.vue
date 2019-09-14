<template>
  <header class="top-bar">
    <div class="header-container">
      <h1>Message Board</h1>
      <button
        class="nav-button"
        @click="$emit('change-mobile-view', 'messages')"
      >
        Messages
      </button>
      <button
        class="nav-button"
        @click="$emit('change-mobile-view', 'ranking')"
      >
        Ranking
      </button>
      <button
        class="icon-button"
        title="Toggle theme"
        @click="$emit('toggle-theme')"
      >
        <Octicon ico="paintcan" />
      </button>
      <a
        class="icon-button"
        href="https://github.com/edsondewes/message-board"
        title="Visit GitHub page"
      >
        <Octicon ico="mark-github" />
      </a>
    </div>
  </header>
</template>

<script>
import Octicon from '../Octicon';

export default {
  name: 'Header',
  components: {
    Octicon,
  },
};
</script>

<style scoped>
.header-container {
  align-content: center;
  display: flex;
  margin: 0 auto;
  max-width: 90%;
}

.icon-button,
.nav-button {
  border: 0;
  background: transparent;
  color: var(--main-color);
}

.icon-button {
  cursor: pointer;
  display: flex;
  align-items: center;
}

.icon-button:focus {
  outline: 0;
}

.icon-button >>> svg {
  height: 24px;
  width: 24px;
}

.nav-button {
  display: none;
}

.top-bar {
  background: var(--header-bg-color);
  border-bottom: 1px solid var(--border-color);
}

.top-bar h1 {
  font-size: 1.2rem;
  flex: 1;
  margin: 0 0.5vw;
  padding: 1.5vh 0;
}

@media only screen and (max-width: 768px) {
  .header-container {
    max-width: 100%;
  }

  .nav-button {
    display: inline;
  }
}
</style>