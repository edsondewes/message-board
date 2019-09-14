<template>
  <!-- eslint-disable vue/no-v-html -->
  <span
    class="octicon"
    v-html="icoSvg"
  />
</template>

<script>
import octicons from '@primer/octicons';

export default {
  name: 'Octicon',
  props: {
    ico: {
      type: String,
      required: true,
    },
  },
  computed: {
    icoSvg() {
      return octicons[this.ico].toSVG();
    },
  },
};
</script>

<style scoped>
.octicon {
  display: inline-block;
  fill: currentColor;
}
</style>