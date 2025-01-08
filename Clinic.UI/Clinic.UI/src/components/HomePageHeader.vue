<template>
  <div class="home-header">
    <img src="/Doctors.jpg" />
    <div class="website-content content-wrapper">
      <h1>Witamy w Mokotowski Clinic!</h1>
      <RouterLink class="btn btn-primary me-2" to="/about">O nas</RouterLink>
      <RouterLink class="btn btn-secondary" to="/login">Zaloguj się</RouterLink>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.home-header {
  display: flex;
  justify-content: center;
  align-items: center;

  img {
    width: 100%;
    height: 750px;
    object-fit: cover;
    object-position: top;
    filter: brightness(70%);
  }

  .btn-primary:hover,
  .btn-primary:active,
  .btn-primary:not(:disabled):active,
  .btn-secondary:hover,
  .btn-secondary:active,
  .btn-secondary:not(:disabled):active {
    background-color: transparent;
    border-color: white;
  }

  .content-wrapper {
    position: absolute;

    h1 {
      font-size: 3.5rem;
      color: white;
    }
  }
}
</style>
