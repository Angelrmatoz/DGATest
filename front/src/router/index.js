import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: HomeView,
        },
        {
            path: '/about',
            name: 'about',
            // división de código a nivel de ruta
            // esto genera un fragmento separado (About.[hash].js) para esta ruta
            // que se carga de forma diferida cuando se visita la ruta
            component: () => import('../views/AboutView.vue'),
        },
        {
            path: '/products',
            name: 'products',
            component: () => import('../views/ProductsView.vue'),
        },
    ],
});
export default router;
