<script setup lang="ts">
import { ref } from 'vue'
import VueDatePicker from '@vuepic/vue-datepicker'
import '@vuepic/vue-datepicker/dist/main.css'
import HeaderText from '../components/HeaderText.vue'
import axios from 'axios'
import type { Appointment } from '../interfaces.ts'
var startDate = new Date()
var range = 7
var endDate = new Date(startDate.setDate(startDate.getDate() + range))
const selectedAppointment = ref<string>('')
const dates = ref([new Date(), endDate])

const appointmentTypes: string[] = [
  'Ogólna konsultacja',
  'Konsultacja stomatologiczna',
  'Wizyta pediatryczna',
  'Konsultacja kardiologiczna',
  'Wizyta dermatologiczna',
]

const emit = defineEmits(['updateData'])

const areDatesInvalid = ref(false)
const isAppointmentTypeInvalid = ref(false)

const searchAppointments = async () => {
  areDatesInvalid.value = dates.value && dates.value[0] && dates.value[1] ? false : true
  isAppointmentTypeInvalid.value = selectedAppointment.value ? false : true

  if (!areDatesInvalid.value && !isAppointmentTypeInvalid.value) {
    await axios
      .get<Appointment[]>(`http://localhost:5013/appointments`, {
        params: {
          dateStart: dates.value[0].toJSON(),
          dateEnd: dates.value[1].toJSON(),
          appointmentType: selectedAppointment,
        },
      })
      .then((response) => {
        emit('updateData', response.data)
      })
      .catch((err) => console.warn(err))
  }
}

const disableDates = (date: Date) => {
  const today = new Date()
  today.setHours(0, 0, 0, 0)
  return date < today
}

// const format = ([dateStart, dateEnd]: [Date, Date]) => {
//   if (!dateEnd) {
//     dateEnd = dateStart
//   }

//   const dayStart = dateStart.getDate()
//   const monthStart = dateStart.getMonth() + 1
//   const yearStart = dateStart.getFullYear()
//   const dayEnd = dateEnd.getDate()
//   const monthEnd = dateEnd.getMonth() + 1
//   const yearEnd = dateEnd.getFullYear()

//   return `${dayStart}/${monthStart}/${yearStart} - ${dayEnd}/${monthEnd}/${yearEnd}`
// }
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
          format="dd/MM/yyyy"
          :disabledDates="disableDates"
          :class="{ 'is-invalid': areDatesInvalid }"
          :enableTimePicker="false"
        />
      </div>
      <div class="service-picker">
        <label>Typ wizyty</label>
        <select
          v-model="selectedAppointment"
          class="form-select"
          :class="{ 'is-invalid': isAppointmentTypeInvalid }"
        >
          <option v-for="type in appointmentTypes">
            {{ type }}
          </option>
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
