<script setup lang="ts">
import { ref } from 'vue'
import VueDatePicker from '@vuepic/vue-datepicker'
import '@vuepic/vue-datepicker/dist/main.css'
import HeaderText from '../components/HeaderText.vue'
import axios from 'axios'
var startDate = new Date()
var range = 7
var endDate = new Date(startDate.setDate(startDate.getDate() + range))
const dates = ref([new Date(), endDate])
var visit;

const searchAppointments = async () => {
  axios
    .post(`http://localhost:5013/login`, null, {
      params: {
        dateStart: String(dates.value[0]),
        dateEnd: String(dates.value[1]),
      },
    })
    .then((response) => console.log(response))
    .catch((err) => console.warn(err))
}

const disableDates = (date: Date) => {
  const today = new Date();
  today.setHours(0, 0, 0, 0);
  return date < today
}
</script>

<template>
  <HeaderText text="Wyszukiwarka wizyt i zabiegów"></HeaderText>
  <div class="website-content">
    <div class="filters-wrapper">
      <div class="date-picker">
        <label>Data (od - do)</label>
        <VueDatePicker
          v-model="dates"
          range
          locale="pl"
          format="dd-MM-yyyy"
          :disabledDates="disableDates"
          :enableTimePicker="false"
        />
      </div>
      <div class="service-picker">
        <label>Typ wizyty</label>
        <select class="form-select">
          <option hidden disabled selected value>Wybierz typ wizyty</option>
          <option>Kardiolog - konsultacja</option>
          <option>Pediatra - konsultacja</option>
          <option>Pobranie krwi</option>
        </select>
      </div>
      <button @click="searchAppointments" type="button" class="btn btn-primary">
        <span class="material-symbols-outlined"> search </span>
        Szukaj
      </button>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.website-content {
  :deep(.dp__menu) {
    --dp-primary-color: var(--secondary-color);
    text-align: center;

    .dp__action_cancel {
      display: none;
    }
  }

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
