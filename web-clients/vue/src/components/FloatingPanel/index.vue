<template>
  <div class="floating-panel">
    <slot />
  </div>
</template>

<script>
export default {
  name: 'FloatingPanel',
};
</script>

<style scoped>
.floating-panel {
  background: var(--warning-bg-color);
  border-radius: 5px;
  box-shadow: 3px 3px 8px var(--warning-border-color);
  bottom: 2vh;
  font-size: 0.8rem;
  padding: 1vw;
  position: fixed;
  right: 1vw;
}

.floating-panel h1 {
  font-size: 1rem;
  margin: 0;
}

@media only screen and (max-width: 768px) {
  .floating-panel {
    border-radius: unset;
    bottom: unset;
    box-shadow: unset;
    display: block;
    position: unset;
    right: unset;
  }

  .floating-panel h1 {
    display: none;
  }
}
</style>