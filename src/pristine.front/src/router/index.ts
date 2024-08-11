import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MobileView from '../views/devices/MobileView.vue'
import DesktopView from '../views/devices/DesktopView.vue'
import TabletView from '../views/devices/TabletView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/devices/mobile',
      name: 'mobile',
      component: MobileView
    },
    {
      path: '/devices/desktop',
      name: 'desktop',
      component: DesktopView
    },
    {
      path: '/devices/tablet',
      name: 'tablet',
      component: TabletView
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../views/AboutView.vue')
    }
  ]
})

export default router
