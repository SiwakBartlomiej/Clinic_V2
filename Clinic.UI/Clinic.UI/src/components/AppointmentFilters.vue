<script setup lang="ts">
import { ref } from 'vue'
import VueDatePicker from '@vuepic/vue-datepicker'
import '@vuepic/vue-datepicker/dist/main.css'
import HeaderText from '../components/HeaderText.vue'
import axios from "axios";
const date = ref(null)

const data = ref<any>(null); // Zmienna do przechowywania odpowiedzi z API
    const error = ref<string | null>(null); // Zmienna do przechowywania błędów
const callApi = async () => {
  try {
    const response = await axios.get("http://localhost:5013/weatherforecast");
    data.value = response.data;
    error.value = null;
    console.log(data.value);
  } catch (err: any) {
    error.value = err.message;
    data.value = null;
  }
};
</script>

<template>
  <HeaderText text="Wyszukiwarka wizyt i zabiegów"></HeaderText>
  <div class="website-content">
    <div class="filters-wrapper">
      <div class="date-picker">
        <label>Data (od - do)</label>
        <VueDatePicker
          v-model="date"
          range
          locale="pl"
          format="dd-MM-yyyy"
          :enableTimePicker="false"
        />
      </div>
      <div class="service-picker">
        <label>Wizyta / zabieg </label>
        <select class="form-select">
          <option hidden disabled selected value>Wybierz wizytę lub zabieg</option>
          <option>Kardiolog - konsultacja</option>
          <option>Pediatra - konsultacja</option>
          <option>Pobranie krwi</option>
        </select>
      </div>
      <button @click="callApi" type="button" class="btn btn-primary">
        <span class="material-symbols-outlined"> search </span>
        Szukaj
      </button>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.website-content {
  h2 {
    display: block;
    text-align: center;
    margin-bottom: 40px;
  }

  .filters-wrapper {
    display: flex;
    gap: 10px;

    .service-picker {
      flex: 1;
      display: flex;
      align-self: flex-end;
      flex-direction: column;

      label {
        text-align: center;
      }
    }

    .date-picker {
      flex: 1;
      display: flex;
      flex-direction: column;

      label {
        text-align: center;
      }
    }

    button {
      flex: 1;
      height: 38px;
      align-self: flex-end;
      display: flex;
      justify-content: center;
    }
  }
}
</style>
