import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import ProductsView from '../views/ProductsView.vue';

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
      component: () => import('../views/AboutView.vue'),
    },
    {
      path: '/products',
      name: 'products',
      component: ProductsView,
    },
    {
      path: '/sales',
      name: 'sales',
      component: () => import('../views/SalesView.vue'),
    },
    // Ruta comodín, redirige a inicio
    {
      path: '/:pathMatch(.*)*',
      redirect: '/',
    },
  ],
});

// Protección de rutas: solo permite acceso si está autenticado
router.beforeEach((to, from, next) => {
  // Rutas públicas (puedes agregar más si tienes otras vistas públicas)
  const publicPages = ['/']; // Solo la raíz es pública (login)
  const authRequired = !publicPages.includes(to.path);
  const token = localStorage.getItem('token');

  if (authRequired && !token) {
    // Si la ruta requiere auth y no hay token, redirige al login
    return next('/');
  }
  next();
});

export default router;
