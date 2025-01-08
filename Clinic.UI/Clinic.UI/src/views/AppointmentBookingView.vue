<script setup lang="ts">
import AppointmentFilters from '../components/AppointmentFilters.vue'
import { ref } from 'vue'
import type Appointment from '../interfaces.ts'
const appointments = ref<Appointment[]>([])

const handleDataUpdate = (data: Appointment[]) => {
  appointments.value = data
}

const formatDate = (date: Date) => {
  date = new Date(date);
  const day = date.getDate().toString().padStart(2, '0');
  const month = (date.getMonth() + 1).toString().padStart(2, '0'); 
  const year = date.getFullYear();

  return `${day}/${month}/${year}`;
}
</script>

<template>
  <AppointmentFilters @updateData="handleDataUpdate"></AppointmentFilters>
  <div class="results website-content">
    <div class="result" v-for="appointment in appointments">
      <p class="date">{{ formatDate(appointment.date) }}</p>
      <p class="service"> {{ appointment.type }}</p>
      <p class="personnel">{{`${appointment.medicalPersonnel.title} ${appointment.medicalPersonnel.firstName}
       ${appointment.medicalPersonnel.lastName}`}}</p>
    </div>
  </div>
</template>
<style lang="scss" scoped>
.results {
  padding-top: 0;

  .result {
    margin-bottom: 30px;
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
      flex: 2;
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
