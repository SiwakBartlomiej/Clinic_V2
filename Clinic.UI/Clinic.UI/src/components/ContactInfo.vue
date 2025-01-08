<template>
  <div class="website-content">
    <div class="image-wrapper">
      <img src="/Nurse.jpg" />
    </div>
    <div class="contact-details">
      <h2>Skontaktuj się z nami</h2>
      <p><strong>Telefon:</strong> +48 519 759 878</p>
      <p><strong>Email:</strong> kontakt@mokotowskiclinic.pl</p>
      <p><strong>Adres:</strong> ul. Mokotowska 24, 02-908 Warszawa</p>
      <p><strong>Godziny otwarcia:</strong> Pon-Pt: 8:00 - 18:00, Sob: 9:00 - 14:00</p>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.website-content {
  display: flex;
  align-items: center;
  gap: 25px;
  .contact-details {
    flex: 1;

    p {
      margin-bottom: 0.5rem;
    }
  }

  .image-wrapper {
    flex: 1;
    text-align: center;

    img {
      object-fit: cover;
      clip-path: circle();
      height: 300px;
      width: 300px;
      object-position: top;
    }
  }
}
</style>
