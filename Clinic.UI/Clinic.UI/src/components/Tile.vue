<script setup lang="ts">
const props = defineProps({
  icon: String,
  text: String,
})
</script>

<template>
  <div class="tile">
    <span class="material-symbols-outlined"> {{ props.icon }} </span>
    <p>
      {{ props.text }}
    </p>
  </div>
</template>

<style lang="scss" scoped>
.tile {
  text-align: center;
  padding: 20px;
  background-color: white;
  border-radius: 10px;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
  width: 33.333%;
  transition:
    transform 0.3s,
    box-shadow 0.3s;
  height: 280px;
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;

  .material-symbols-outlined {
    font-size: 70px;
    color: var(--primary-color);
  }

  &:hover {
    transform: translateY(-5px);
    box-shadow: 0 6px 10px rgba(0, 0, 0, 0.2);
  }
}
</style>
