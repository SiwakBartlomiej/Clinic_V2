<script setup lang="ts">
import axios from 'axios'
import { ref } from 'vue'
import HeaderText from '../components/HeaderText.vue'
import type { ContactInformation } from "../interfaces.ts"

const contactInfo = ref<ContactInformation>();
const patient_id = 4;

const getContactInformation = async () => {
  await axios
    .get<ContactInformation>(`http://localhost:5013/patients/${patient_id}/contact-information`)
    .then((response) => {
      contactInfo.value = response.data;
      })
    .catch((err) => console.warn(err))
}

getContactInformation();
</script>

<template>
  <HeaderText text="Panel pacjenta"></HeaderText>
  <div class="website-content">
    <div>
      <h2>Wizyty Nadchodzące</h2>
      <p>Brak zaplanowanych wizyt.</p>
    </div>

    <div>
      <h2>Wizyty Zakończone</h2>
      <p>Nie ma zakończonych wizyt do wyświetlenia.</p>
    </div>

    <div>
      <h2>Wyniki Badań</h2>
      <p>Brak dostępnych wyników badań.</p>
    </div>

    <div>
      <h2>Dane Kontaktowe</h2>
      <p>{{ contactInfo?.address?.city }} {{ contactInfo?.address?.postalCode }} {{ contactInfo?.address?.street }}</p>
      <p>{{ contactInfo?.phone }}</p>
      <p>{{ contactInfo?.email }}</p>
    </div>
  </div>
</template>
