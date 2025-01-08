<script setup lang="ts">
import HeaderText from '../components/HeaderText.vue'
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
      <p>Mokotowski Clinic</p>
      <p>ul. Przykładowa 123, 00-001 Warszawa</p>
      <p>Telefon: +48 123 456 789</p>
      <p>Email: kontakt@mokotowskaclinic.pl</p>
    </div>
  </div>
</template>
