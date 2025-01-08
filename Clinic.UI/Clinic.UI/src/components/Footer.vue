<script setup lang="ts">
const currentYear = new Date().getFullYear()
</script>

<template>
  <footer>
    <div class="footer-content website-content">
      <div class="company-name">Mokotowski Clinic</div>
      <ul class="footer-links">
        <li><RouterLink to="/about">O nas</RouterLink></li>
        <li><RouterLink to="/login">Logowanie</RouterLink></li>
        <li><RouterLink to="/contact">Kontakt</RouterLink></li>
      </ul>
      <div class="footer-socials">
        <RouterLink to="/"><img src="/FacebookIcon.svg" /></RouterLink>
        <RouterLink to="/"><img src="/InstagramIcon.svg" /></RouterLink>
      </div>
    </div>
    <div class="footer-bottom website-content">
      <p>&copy; {{ currentYear }} Mokotowski Clinic. Wszelkie prawa zastrzeżone.</p>
    </div>
  </footer>
</template>

<style lang="scss" scoped>
footer {
  background-color: var(--primary-color);
  padding: 20px;
  color: white;

  .footer-content {
    display: flex;
    gap: 20px;
    align-items: center;
    padding: 0;

    .company-name {
      flex: 1;
    }

    .footer-links {
      display: flex;
      gap: 20px;
      justify-content: center;
      a {
        color: white;
      }
    }

    .footer-socials {
      display: flex;
      gap: 15px;
      flex: 1;
      justify-content: flex-end;
    }
  }

  .footer-bottom {
    font-size: 0.9rem;
    opacity: 0.8;
    text-align: center;
    padding: 0;
    p {
      margin: 1rem 0;
    }
  }
}
</style>
