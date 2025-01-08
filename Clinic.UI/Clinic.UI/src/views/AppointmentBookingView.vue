<script setup lang="ts">
import AppointmentFilters from '../components/AppointmentFilters.vue'
</script>

<template>
  <AppointmentFilters></AppointmentFilters>
  <div class="results website-content">
    <div class="result">
      <p class="date">17/01/2025 10:30</p>
      <p class="service">Kardiolog - konsultacja</p>
      <p class="personnel">dr n. med. Andrzej Chropowiński</p>
    </div>
    <div class="result">
      <p class="date">17/01/2025 08:15</p>
      <p class="service">Kardiolog - konsultacja</p>
      <p class="personnel">dr n. med. Andrzej Chropowiński</p>
    </div>
    <div class="result">
      <p class="date">17/01/2025 17:00</p>
      <p class="service">Kardiolog - konsultacja</p>
      <p class="personnel">dr n. med. Andrzej Chropowiński</p>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.results {
  padding-top: 0;

  .result {
    margin-bottom: 30px;
    display: flex;
    gap: 10px;
    border: 1px solid gray;
    border-radius: 5px;
    text-align: center;
    justify-content: center;
    padding: 20px;

    p {
      margin-bottom: 0;
    }

    .date {
      flex: 2;
    }

    .service {
      flex: 5;
    }

    .personnel {
      flex: 5;
    }
  }
}
</style>
