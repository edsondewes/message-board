<template>
  <div class="message empty-container">
    <p>
      <strong>We don&apos;t have any messages yet</strong>
    </p>
    <p>Be the first to spread your words!</p>
  </div>
</template>

<script>
export default {
  name: 'EmptyListInfo'
}
</script>

<style scoped>
.empty-container {
  color: var(--secondary-color);
  padding: 2vh;
  text-align: center;
}

.message {
  background: var(--content-bg-color);
  border: 1px solid var(--border-color);
  margin-bottom: 1vh;
  padding: 2vh 1vw;
}

.message p {
  font-size: 1rem;
  margin: 0 0 1.5vh;
}
</style>