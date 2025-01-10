<script setup lang="ts">
import HeaderText from '../components/HeaderText.vue'
</script>

<template>
  <HeaderText text="Nie znaleziono strony"></HeaderText>
  <h3 class="website-content">
    Możesz wrócić do strony głównej klikając <RouterLink to="/">tutaj.</RouterLink>
  </h3>
</template>

<style lang="scss" scoped>
.website-content {
  a {
    font-size: inherit;
    line-height: inherit;
  }
}
</style>
