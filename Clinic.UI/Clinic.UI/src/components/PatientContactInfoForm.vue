<script setup lang="ts">
import type { ContactInformation } from '../interfaces.ts'

interface Props {
  contactInformation: ContactInformation
}

defineProps<Props>()
</script>

<template>
  <div>
    <label for="postalCode">Kod pocztowy:</label>
    <input
      class="form-control"
      id="postalCode"
      type="text"
      v-model="contactInformation.address.postalCode"
      required
    />
  </div>
  <div>
    <label for="city">Miasto:</label>
    <input
      class="form-control"
      id="city"
      type="text"
      v-model="contactInformation.address.city"
      required
    />
  </div>
  <div>
    <label for="street">Ulica:</label>
    <input
      class="form-control"
      id="street"
      type="text"
      v-model="contactInformation.address.street"
      required
    />
  </div>
  <div>
    <label for="phone">Numer telefonu:</label>
    <input
      class="form-control"
      id="phone"
      type="text"
      v-model="contactInformation.phone"
      required
    />
  </div>
  <div>
    <label for="email">E-mail:</label>
    <input
      class="form-control"
      id="email"
      type="email"
      v-model="contactInformation.email"
      required
    />
  </div>
</template>

<style lang="scss" scoped>
form {
  input {
    margin-bottom: 10px;
  }

  label {
    margin-right: 5px;
    font-weight: 700;
  }

  .btn {
    margin-top: 10px;
  }

  .btn-primary {
    margin-right: 5px;
  }
}
</style>
