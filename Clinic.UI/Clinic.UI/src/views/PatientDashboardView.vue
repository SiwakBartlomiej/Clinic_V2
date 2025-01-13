<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'
import HeaderText from '../components/HeaderText.vue'
import type { Appointment, ContactInformation } from '../interfaces.ts'
import { formatDate, getMedicalPersonnelFullName } from '../utils.ts'
import cloneDeep from 'lodash.clonedeep'

const contactInfo = ref<ContactInformation>()
const updatedContactInfo = ref<ContactInformation>()
const appointments = ref<Appointment[]>([])
const finishedAppointments = ref<Appointment[]>([])
const upcomingAppointments = ref<Appointment[]>([])
const patient_id = 4
const isEditing = ref(false)

const getContactInformation = async () => {
  await axios
    .get<ContactInformation>(`http://localhost:5013/patients/${patient_id}/contact-information`)
    .then((response) => {
      contactInfo.value = response.data
      updatedContactInfo.value = cloneDeep(response.data)
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

const updateContactInformation = async () => {
  isEditing.value = false

  axios
    .put<ContactInformation>(
      `http://localhost:5013/patients/${patient_id}/contact-information`,
      updatedContactInfo.value,
      {
        params: {
          patientId: patient_id,
        },
      },
    )
    .then((response) => (contactInfo.value = response.data))
    .catch((err) => console.warn(err))
    .finally((updatedContactInfo.value = cloneDeep(contactInfo.value)))
}

const handleCancel = () => {
  isEditing.value = false
  updatedContactInfo.value = cloneDeep(contactInfo.value)
}

getContactInformation()
getAppointments()
</script>

<template>
  <HeaderText text="Panel pacjenta"></HeaderText>
  <div class="website-content">
    <div>
      <h2>Wizyty Nadchodzące</h2>
      <div class="appointment-labels">
        <label>Data:</label>
        <label>Typ wizyty:</label>
        <label>Lekarz:</label>
        <label>Przyczyna:</label>
        <label>Diagnoza:</label>
      </div>
      <div class="appointment" v-for="appointment in upcomingAppointments">
        <div>{{ formatDate(appointment.date) }}</div>
        <div>{{ appointment.type }}</div>
        <div>{{ getMedicalPersonnelFullName(appointment.medicalPersonnel) }}</div>
        <div>{{ appointment.reason }}</div>
        <div>{{ appointment.diagnosis }}</div>
      </div>
    </div>

    <div>
      <h2>Wizyty Zakończone</h2>
      <div class="appointment-labels">
        <label>Data:</label>
        <label>Typ wizyty:</label>
        <label>Lekarz:</label>
        <label>Przyczyna:</label>
        <label>Diagnoza:</label>
      </div>
      <div class="appointment" v-for="appointment in finishedAppointments">
        <div>{{ formatDate(appointment.date) }}</div>
        <div>{{ appointment.type }}</div>
        <div>{{ getMedicalPersonnelFullName(appointment.medicalPersonnel) }}</div>
        <div>{{ appointment.reason }}</div>
        <div>{{ appointment.diagnosis }}</div>
      </div>
    </div>

    <div>
      <h2>Wyniki Badań</h2>
      <p>Brak dostępnych wyników badań.</p>
    </div>

    <div v-if="contactInfo && updatedContactInfo">
      <h2>Dane Kontaktowe</h2>

      <div v-if="!isEditing">
        <p>
          <strong>Adres:</strong> {{ contactInfo.address.postalCode }}
          {{ contactInfo.address.city }}, {{ contactInfo.address.street }}
        </p>
        <p><strong>Numer telefonu:</strong> {{ contactInfo.phone }}</p>
        <p><strong>E-mail:</strong> {{ contactInfo.email }}</p>
        <button class="btn btn-primary" @click="isEditing = true">Edytuj dane</button>
      </div>

      <form v-if="isEditing" @submit.prevent="updateContactInformation">
        <div>
          <label for="postalCode"><strong>Kod pocztowy:</strong></label>
          <input id="postalCode" type="text" v-model="updatedContactInfo.address.postalCode" />
        </div>
        <div>
          <label for="city"><strong>Miasto:</strong></label>
          <input id="city" type="text" v-model="updatedContactInfo.address.city" />
        </div>
        <div>
          <label for="street"><strong>Ulica:</strong></label>
          <input id="street" type="text" v-model="updatedContactInfo.address.street" />
        </div>
        <div>
          <label for="phone"><strong>Numer telefonu:</strong></label>
          <input id="phone" type="text" v-model="updatedContactInfo.phone" />
        </div>
        <div>
          <label for="email"><strong>E-mail:</strong></label>
          <input id="email" type="email" v-model="updatedContactInfo.email" />
        </div>
        <button class="btn btn-primary" type="submit" @click="">Zapisz dane</button>
        <button class="btn btn-secondary" type="button" @click="handleCancel">Anuluj</button>
      </form>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.website-content {
  .appointment,
  .appointment-labels {
    width: 100%;
    display: flex;
    justify-content: space-evenly;
    padding: 20px;
    margin-bottom: 30px;
    border: 1px solid black;
    border-radius: 10px;
  }

  .appointment-labels {
    label {
      font-weight: bold;
    }
    border: none;
    padding: 0;
    margin-bottom: 5px;
  }

  form {
    input {
      margin-bottom: 10px;
    }

    label {
      margin-right: 5px;
    }

    .btn {
      margin-top: 10px;
    }

    .btn-primary {
      margin-right: 5px;
    }
  }
}
</style>
