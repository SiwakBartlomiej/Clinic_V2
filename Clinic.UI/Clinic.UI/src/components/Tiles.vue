<script setup lang="ts">
import Tile from '../components/Tile.vue'

const tiles = [
  {
    icon: 'ecg_heart',
    text: 'Profesjonalna opieka i indywidualne podejście. Jesteśmy tu, aby zadbać o Ciebie i Twoje potrzeby zdrowotne.',
  },
  {
    icon: 'pill',
    text: 'Twoje zdrowie w naszych rękach. Skorzystaj z fachowej porady lekarzy oraz dobierz odpowiednie leki i suplementy dla siebie.',
  },
  {
    icon: 'outpatient_med',
    text: 'Z nami zawsze masz szybki dostęp do pomocy medycznej. Umów wizytę lub dowiedz się, jak skorzystać z naszych usług w prostych krokach!',
  },
]
</script>

<template>
  <div class="website-content">
    <Tile v-bind="tile" v-for="tile in tiles" />
  </div>
</template>

<style lang="scss" scoped>
.website-content {
  gap: 15px;
  display: flex;
  justify-content: space-around;
}
</style>
