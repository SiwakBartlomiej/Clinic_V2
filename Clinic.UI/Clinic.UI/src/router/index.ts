import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AboutUsView from '../views/AboutUsView.vue'
import LoginView from '../views/LoginView.vue'
import ContactView from '../views/ContactView.vue'
import AppointmentBookingView from '../views/AppointmentBookingView.vue'
import PatientDashboardView from '../views/PatientDashboardView.vue'
import ErrorView from '../views/ErrorView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView,
    },
    {
      path: '/about',
      name: 'about',
      component: AboutUsView,
    },
    {
      path: '/contact',
      name: 'contact',
      component: ContactView,
    },
    {
      path: '/appointment-booking',
      name: 'appointmentBooking',
      component: AppointmentBookingView,
    },
    {
      path: '/patient-dashboard',
      name: 'patientDashboard',
      component: PatientDashboardView,
    },
    {
      path: '/:pathMatch(.*)*',
      name: 'errorView',
      component: ErrorView,
    },
  ],
})

export default router
