<script setup lang="ts">
import { ref } from 'vue'
import axios from 'axios'
const data = ref<any>(null)

const callApi = async () => {
  try {
    console.log('XD')
    data.value = await axios.get('http://localhost:5013/weatherforecast')
    console.log(data.value)
  } catch (err: any) {
    console.log('wtf')
  }
}
</script>

<template>
  <div class="website-content">
    <div class="login-container">
      <form class="login-form">
        <h1 class="login-title">Zaloguj się</h1>
        <div class="form-group">
          <label for="username">Nazwa użytkownika</label>
          <input type="text" name="username" placeholder="Wprowadź nazwę użytkownika" required />
        </div>
        <div class="form-group">
          <label for="password">Hasło</label>
          <input type="password" name="password" placeholder="Wprowadź hasło" required />
        </div>
        <button @click="callApi" type="submit" class="btn btn-primary">
          <RouterLink to="/appointment-booking">Zaloguj się</RouterLink>
        </button>
        <p class="help-text">
          Nie pamiętasz hasła lub chcesz zostać naszym pacjentem? Skontaktuj się z nami
          <RouterLink to="/contact">tutaj.</RouterLink>
        </p>
      </form>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.website-content {
  display: flex;
  justify-content: center;
  align-items: center;
  .login-container {
    padding: 20px;
    color: var(--primary-color);
    background-color: white;
    border-radius: 10px;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    width: 680px;

    .login-title {
      font-size: 1.8rem;
      text-align: center;
    }

    .form-group {
      margin-bottom: 15px;
    }

    label {
      font-size: 0.9rem;
    }

    .btn-primary {
      width: 100%;
      margin-top: 15px;

      a {
        color: white;
      }
    }

    input {
      width: 100%;
      padding: 10px;
      margin-top: 5px;
      border: 1px solid #ccc;
      border-radius: 5px;

      &:focus {
        border-color: var(--primary-color);
        outline: none;
        box-shadow: 0 0 5px rgba(0, 77, 153, 0.5);
        transition: all 0.3s ease-in-out;
      }
    }

    .help-text {
      margin-top: 15px;
      font-size: 0.9rem;
    }
  }
}
</style>
