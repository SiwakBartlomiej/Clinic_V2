<script setup lang="ts">
const props = defineProps({
  header: String,
  teaser: String,
  imagePath: String,
  isImageFirst: Boolean,
})
</script>

<template>
  <div class="content-side-by-side" v-if="!isImageFirst">
    <div class="text-wrapper">
      <h3>{{ props.header }}</h3>
      <p>{{ props.teaser }}</p>
    </div>
    <div class="image-wrapper">
      <img :src="props.imagePath" />
    </div>
  </div>
  <div class="content-side-by-side" v-else>
    <div class="image-wrapper">
      <img :src="props.imagePath" />
    </div>
    <div class="text-wrapper">
      <h3>{{ props.header }}</h3>
      <p>{{ props.teaser }}</p>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.content-side-by-side {
  display: flex;
  align-items: center;
  padding: 20px 0;

  .text-wrapper {
    flex: 11;
    padding-top: 20px;
    margin: 0 50px;
  }

  h3,
  p {
    width: 100%;
  }

  .image-wrapper {
    flex: 9;

    img {
      height: 366px;
      width: 100%;
      object-fit: cover;
    }
  }
}
</style>
