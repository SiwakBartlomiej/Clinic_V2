<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'
import HeaderText from '../components/HeaderText.vue'
import type { Appointment, ContactInformation } from '../interfaces.ts'
import { formatDate, getMedicalPersonnelFullName } from '../utils.ts'

const contactInfo = ref<ContactInformation>()
const appointments = ref<Appointment[]>([])
const finishedAppointments = ref<Appointment[]>([])
const upcomingAppointments = ref<Appointment[]>([])
const patient_id = 4

const getContactInformation = async () => {
  await axios
    .get<ContactInformation>(`http://localhost:5013/patients/${patient_id}/contact-information`)
    .then((response) => {
      contactInfo.value = response.data
    })
    .catch((err) => console.warn(err))
}

const getAppointments = async () => {
  await axios
    .get<Appointment[]>(`http://localhost:5013/patients/${patient_id}/appointments`)
    .then((response) => {
      appointments.value = response.data
      splitAppointments()
    })
    .catch((err) => console.warn(err))
}

const splitAppointments = () => {
  appointments.value.forEach((appointment) => {
    if (new Date(appointment.date) < new Date()) {
      finishedAppointments.value.push(appointment)
    } else {
      upcomingAppointments.value.push(appointment)
    }
  })
}

getContactInformation()
getAppointments()
</script>

<template>
  <HeaderText text="Panel pacjenta"></HeaderText>
  <div class="website-content">
    <div>
      <h2>Wizyty Nadchodzące</h2>
      <div class="appointment" v-for="appointment in upcomingAppointments">
        <div>{{ formatDate(appointment.date) }}</div>
        <div>{{ getMedicalPersonnelFullName(appointment.medicalPersonnel) }}</div>
        <div>{{ appointment.reason }}</div>
        <div>{{ appointment.diagnosis }}</div>
        <div>{{ appointment.type }}</div>
      </div>
    </div>

    <div>
      <h2>Wizyty Zakończone</h2>
      <div class="appointment" v-for="appointment in finishedAppointments">
        <div>{{ formatDate(appointment.date) }}</div>
        <div>{{ getMedicalPersonnelFullName(appointment.medicalPersonnel) }}</div>
        <div>{{ appointment.reason }}</div>
        <div>{{ appointment.diagnosis }}</div>
        <div>{{ appointment.type }}</div>
      </div>
    </div>

    <div>
      <h2>Wyniki Badań</h2>
      <p>Brak dostępnych wyników badań.</p>
    </div>

    <div>
      <h2>Dane Kontaktowe</h2>
      <strong>Adres:</strong>
      <p>
        {{ contactInfo?.address?.postalCode }} {{ contactInfo?.address?.city }}, {{ contactInfo?.address?.street }}
      </p>
      <strong>Numer telefonu:</strong>
      <p>{{ contactInfo?.phone }}</p>
      <strong>E-mail:</strong>
      <p>{{ contactInfo?.email }}</p>
      <button class="btn btn-primary">Zaktualizuj dane</button>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.website-content {
  .appointment {
    width: 100%;
    display: flex;
  }

  .btn-primary {
    width: fit-content;
  }
}
</style>
