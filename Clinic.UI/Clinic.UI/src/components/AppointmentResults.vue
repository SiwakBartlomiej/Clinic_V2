<script setup lang="ts">
import type Appointment from '../interfaces.ts'
import Modal from "./Modal.vue"

const props = defineProps({
  appointments: Array<Appointment>,
})

const formatDate = (date: Date) => {
  date = new Date(date)
  const day = date.getDate().toString().padStart(2, '0')
  const month = (date.getMonth() + 1).toString().padStart(2, '0')
  const year = date.getFullYear()

  const hours = date.getHours().toString().padStart(2, '0')
  const minutes = date.getMinutes().toString().padStart(2, '0')

  return `${day}/${month}/${year} ${hours}:${minutes}`
}
</script>

<template>
  <div class="results website-content">
    <button
      class="result"
      type="button"
      data-toggle="modal"
      data-target="#exampleModal"
      v-for="appointment in appointments"
    >
      <p class="date">{{ formatDate(appointment.date) }}</p>
      <p class="service">{{ appointment.type }}</p>
      <p class="personnel">
        {{
          `${appointment.medicalPersonnel.title} ${appointment.medicalPersonnel.firstName} ${appointment.medicalPersonnel.lastName}`
        }}
      </p>
    </button>
  </div>
    <Modal></Modal>
</template>

<style lang="scss" scoped>
.results {
  padding-top: 0;

  .result {
    width: 100%;
    margin-bottom: 30px;
    background-color: transparent;
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
      flex: 3;
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
