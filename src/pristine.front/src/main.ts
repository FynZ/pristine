import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import { createAuth0 } from '@auth0/auth0-vue';

import PrimeVue from 'primevue/config';
import Aura from '@primevue/themes/aura';
import Lara from '@primevue/themes/lara';
import Nora from '@primevue/themes/nora';

const app = createApp(App)

app.use(
    createAuth0({
      domain: "fynziswag.eu.auth0.com",
      clientId: "TWMPbwQWJw5H2LLYyMqKyWB3awfG9cBQ",
      authorizationParams: {
        redirect_uri: window.location.origin
      }
    })
  );

app.use(PrimeVue, {
    // Default theme configuration
    theme: {
        preset: Aura,

        options: {
          
          darkModeSelector: '.my-app-dark',
      }
    }
});

app.use(createPinia())
app.use(router)

app.mount('#app')
