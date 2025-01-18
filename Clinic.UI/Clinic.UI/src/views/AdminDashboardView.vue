<script setup lang="ts">
import { ref } from 'vue'
import type { Patient } from '@/interfaces'
import HeaderText from '../components/HeaderText.vue'
import VueDatePicker from '@vuepic/vue-datepicker'
import PatientContactInfoForm from '@/components/PatientContactInfoForm.vue'
import axios from 'axios'

const patient = ref<Patient>({
  id: 0,
  firstName: '',
  lastName: '',
  contactInfo: {
    email: '',
    phone: '',
    address: {
      street: '',
      postalCode: '',
      city: '',
    },
  },
  dateOfBirth: new Date(),
  gender: '',
})

const createPatient = async () => {
  axios
    .post<Patient>(`http://localhost:5013/patient`, patient.value)
    .then((response) => console.log(response))
    .catch((err) => console.log(err.message))
}
</script>

<template>
  <HeaderText text="Panel administratora" />
  <div class="website-content">
    <button class="btn btn-primary">Dodaj pacjenta</button>
    <button class="btn btn-primary">Dodaj personel medyczny</button>
    <form id="patientForm" @submit.prevent="createPatient">
      <label for="firstname">Imię:</label><br />
      <input
        type="text"
        id="firstname"
        name="firstname"
        v-model="patient.firstName"
        class="form-control"
        required
      /><br /><br />

      <label for="lastname">Nazwisko:</label><br />
      <input
        type="text"
        id="lastname"
        name="lastname"
        v-model="patient.lastName"
        class="form-control"
        required
      /><br /><br />

      <label for="dateofbirth">Data urodzenia:</label><br />
      <VueDatePicker
        v-model="patient.dateOfBirth"
        locale="pl"
        format="dd/MM/yyyy"
        :enableTimePicker="false"
      />

      <label for="gender">Płeć:</label><br />
      <select class="form-select" required>
        <option value="Male">Mężczyzna</option>
        <option value="Female">Kobieta</option></select
      ><br /><br />
      <PatientContactInfoForm :contact-information="patient.contactInfo"></PatientContactInfoForm>
      <button class="btn btn-primary" type="submit" @click="">Dodaj</button>
    </form>
  </div>
</template>

<style lang="scss" scoped>
.website-content {
  label {
    font-weight: 700;
  }
}
</style>
