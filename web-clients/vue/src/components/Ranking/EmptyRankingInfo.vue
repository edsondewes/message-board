<template>
  <div class="empty-container">
    <p>Our ranking is still empty</p>
    <p>Vote for some messages and refresh the page to see the results</p>
  </div>
</template>

<script>
export default {
  name: 'EmptyRankingInfo'
}
</script>

<style scoped>
.empty-container {
  color: var(--secondary-color);
}
</style>