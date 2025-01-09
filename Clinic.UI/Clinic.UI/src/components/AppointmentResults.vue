<script setup lang="ts">
import type Appointment from '../interfaces.ts'
import Modal from './Modal.vue'
import axios from 'axios'

var selectedAppointmentId: number

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

const bookAppointment = async () => {
  axios
    .post(`http://localhost:5013/book-appointment`, null, {
      params: {
        appointmentId: selectedAppointmentId,
      },
    })
    .then((response) => console.log(response))
    .catch((err) => console.warn(err))
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
      @click="selectedAppointmentId = appointment.id"
    >
      <p class="date">{{ formatDate(appointment.date) }}</p>
      <p class="service">{{ appointment.type }}</p>
      <p class="personnel">
        {{
          `${appointment.medicalPersonnel.title} ${appointment.medicalPersonnel.firstName} ${appointment.medicalPersonnel.lastName}`
        }}
      </p>
      <span class="material-symbols-outlined"> arrow_forward_ios </span>
    </button>
    <Modal
      @modal-action="bookAppointment"
      title="Czy potwierdzasz wizytę?"
      btn-cancel-text="Anuluj"
      btn-confirm-text="Potwierdzam"
    ></Modal>
  </div>
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
    transition: transform 0.3s ease;

    &:hover {
      transform: translateX(20px);
    }

    p {
      margin-bottom: 0;
    }

    .date {
      flex: 2;
    }

    .service {
      flex: 4;
    }

    .personnel {
      flex: 4;
    }

    .material-symbols-outlined {
      flex: 1;
    }
  }
}
</style>
