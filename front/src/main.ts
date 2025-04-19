import { createApp } from 'vue';
import { createPinia } from 'pinia';

import App from './App.vue';
import router from './router';

// Importar estilos SCSS globales
import './styles/_variables.scss';
import './styles/main.scss';
import './styles/_app.scss';
// No necesitamos importar aquí los estilos de vistas o componentes
// ya que se importan directamente en sus archivos Vue respectivos

// Crear la app
const app = createApp(App);

// Usar plugins
app.use(createPinia());
app.use(router);

// Montar la app
app.mount('#app');
