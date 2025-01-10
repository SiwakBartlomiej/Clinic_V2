<script setup lang="ts">
import AppointmentFilters from '../components/AppointmentFilters.vue'
import AppointmentResults from '../components/AppointmentResults.vue'
import { ref } from 'vue'
import type { Appointment } from '../interfaces.ts'

const appointments = ref<Appointment[]>([])
const handleDataUpdate = (data: Appointment[]) => {
  appointments.value = data
}
</script>

<template>
  <AppointmentFilters @updateData="handleDataUpdate"></AppointmentFilters>
  <AppointmentResults :appointments="appointments"></AppointmentResults>
</template>
