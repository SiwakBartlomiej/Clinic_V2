<script setup lang="ts">
import { ref } from 'vue'
import type { Appointment } from '../interfaces.ts'
import Modal from './Modal.vue'
import axios from 'axios'
import { formatDate, getMedicalPersonnelFullName } from '../utils.ts'
defineProps({
  appointments: Array<Appointment>,
})

const patientId = 4
const selectedAppointment = ref<Appointment>()
const bookedSuccessfully = ref<boolean>()

const bookAppointment = async () => {
  axios
    .post(`http://localhost:5013/book-appointment`, null, {
      params: {
        appointmentId: selectedAppointment.value?.id,
        patientId: patientId,
      },
    })
    .then((response) => (bookedSuccessfully.value = response.status === 200))
    .catch(() => (bookedSuccessfully.value = false))
}
</script>

<template>
  <div class="results website-content">
    <button
      class="result"
      type="button"
      data-toggle="modal"
      data-target="#modal"
      v-for="appointment in appointments"
      @click="selectedAppointment = appointment"
    >
      <p class="date">{{ formatDate(appointment.date) }}</p>
      <p class="service">{{ appointment.type }}</p>
      <p class="personnel">
        {{ getMedicalPersonnelFullName(appointment.medicalPersonnel) }}
      </p>
      <span class="material-symbols-outlined"> arrow_forward_ios </span>
    </button>
    <Modal
      @modal-action="bookAppointment"
      title="Czy na pewno chcesz umówić wizytę?"
      btn-cancel-text="Anuluj"
      btn-confirm-text="Potwierdzam"
    >
      <template #body>
        <label>Typ wizyty:</label>
        <h4>{{ selectedAppointment?.type }}</h4>
        <label>Data:</label>
        <h4>{{ formatDate(selectedAppointment?.date ?? new Date()) }}</h4>
        <label>Lekarz:</label>
        <h4>{{ getMedicalPersonnelFullName(selectedAppointment?.medicalPersonnel) }}</h4>
        <p v-if="bookedSuccessfully !== undefined && bookedSuccessfully" class="text-success">
          Wizyta umówiona pomyślnie.
        </p>
        <p v-if="bookedSuccessfully !== undefined && !bookedSuccessfully" class="text-danger">
          Coś poszło nie tak, spróbuj ponownie później.
        </p>
      </template>
    </Modal>
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
