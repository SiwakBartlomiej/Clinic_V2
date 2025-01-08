<template>
  <nav class="navbar">
    <div class="website-content">
      <RouterLink class="company-name" to="/">Mokotowski Clinic</RouterLink>
      <ul class="nav-links">
        <li><RouterLink to="/patient-dashboard">Panel pacjenta</RouterLink></li>
        <li><RouterLink to="/about">O nas</RouterLink></li>
        <li><RouterLink to="/login">Logowanie</RouterLink></li>
        <li><RouterLink to="/contact">Kontakt</RouterLink></li>
      </ul>
    </div>
  </nav>
</template>

<style lang="scss" scoped>
.navbar {
  background-color: var(--primary-color);
  padding: 0 20px;

  .website-content {
    display: flex;
    justify-content: space-between;
    width: 100%;
    padding: 0;
  }

  .company-name {
    display: flex;
    align-items: center;
    color: white;
  }
}

.nav-links {
  display: flex;

  li {
    margin-left: 20px;
  }

  a {
    display: block;
    padding: 20px 10px;
    color: white;
  }
}
</style>
