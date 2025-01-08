<script setup lang="ts">
import HeaderText from '../components/HeaderText.vue'
import ContentSideBySide from '../components/ContentSideBySide.vue'

interface ContentSideBySideProps {
  header: string
  teaser: string
  imagePath: string
  isImageFirst: boolean
}

const contentSideBySideItems: ContentSideBySideProps[] = [
  {
    header: 'Zdrowie i Komfort w Centrum Uwagi',
    teaser:
      'W Mokotowski Clinic priorytetem jest zdrowie i komfort pacjentów. Nasz zespół wysoko wykwalifikowanych specjalistów zapewnia kompleksową opiekę, dostosowaną do indywidualnych potrzeb. Łączymy nowoczesne technologie medyczne z osobistym podejściem, oferując precyzyjne diagnozy i skuteczne terapie.',
    imagePath: '/MedicalEquipment.jpg',
    isImageFirst: true,
  },
  {
    header: 'Szybka Pomoc i Profesjonalna Opieka',
    teaser:
      'Wiemy, jak ważne jest szybkie i skuteczne działanie, dlatego oferujemy konsultacje specjalistyczne w nagłych przypadkach oraz wsparcie w długoterminowym leczeniu. Każdy pacjent jest dla nas wyjątkowy, a jego zdrowie i dobre samopoczucie to nasz priorytet. Mokotowski Clinic to miejsce, gdzie troska o pacjenta łączy się z profesjonalizmem i pasją. Jesteśmy Twoim zaufanym partnerem w dążeniu do zdrowia.',
    imagePath: '/Pills.jpg',
    isImageFirst: false,
  },
  {
    header: 'Nowoczesna Opieka, Dostosowana do Ciebie',
    teaser:
      'Zapewniamy kompleksową, spersonalizowaną opiekę, dostosowaną do indywidualnych potrzeb. Łączymy nowoczesne technologie medyczne z osobistym podejściem, wykorzystując zaawansowany sprzęt diagnostyczny i leczniczy, który umożliwia precyzyjne diagnozy i skuteczne terapie.',
    imagePath: '/Laboratory.jpg',
    isImageFirst: true,
  },
]
</script>

<template>
  <HeaderText text="O naszej klinice" />
  <div class="website-content">
    <ContentSideBySide v-bind="item" v-for="item in contentSideBySideItems" />
  </div>
</template>
