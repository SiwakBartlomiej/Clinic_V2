<script setup lang="ts">
const props = defineProps({
  text: String,
})
</script>

<template>
  <div class="header">
    <h1 class="website-content">{{ props.text }}</h1>
  </div>
</template>

<style lang="scss" scoped>
.header {
  background-image: linear-gradient(to bottom, #001f3e, #374d6a, #6c8099, #a4b7cb, #e1f1ff);
  text-align: center;

  h1 {
    color: white;
  }
}
</style>
