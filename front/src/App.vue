<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router';
import { useAuth } from '@/composables/useAuth';

// Usar el composable para la lógica de autenticación
const { isAuthenticated, username, password, errorMessage, handleLogin, handleLogout } = useAuth();
</script>

<template>
  <!-- Mostrar formulario de login si no está autenticado -->
  <div v-if="!isAuthenticated" class="login-container">
    <div class="login-card">
      <div class="login-logo">
        <img alt="Logo" src="@/assets/logo.svg" />
      </div>

      <h2 class="login-title">Sistema de Gestión</h2>

      <form @submit.prevent="handleLogin" class="login-form">
        <div class="form-group">
          <label for="username">Usuario</label>
          <input
            id="username"
            v-model="username"
            type="text"
            required
            placeholder="Ingrese su usuario"
          />
        </div>

        <div class="form-group">
          <label for="password">Contraseña</label>
          <input
            id="password"
            v-model="password"
            type="password"
            required
            placeholder="Ingrese su contraseña"
          />
        </div>

        <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>

        <button type="submit" class="login-button">Iniciar Sesión</button>
      </form>
    </div>
  </div>

  <!-- Mostrar la aplicación principal si está autenticado -->
  <div v-else class="app">
    <header class="app-header">
      <div class="container">
        <div class="logo-container">
          <img alt="Logo" class="logo" src="@/assets/logo.svg" width="40" height="40" />
          <h1 class="app-title">Sistema de Gestión</h1>
        </div>

        <nav class="main-nav">
          <RouterLink to="/" class="nav-link">Inicio</RouterLink>
          <RouterLink to="/products" class="nav-link">Productos</RouterLink>
          <RouterLink to="/about" class="nav-link">Acerca de</RouterLink>
        </nav>

        <button @click="handleLogout" class="logout-button">Cerrar Sesión</button>
      </div>
    </header>

    <main class="app-content">
      <div class="container">
        <RouterView />
      </div>
    </main>

    <footer class="app-footer">
      <div class="container">
        <p>&copy; {{ new Date().getFullYear() }} Sistema de Gestión de Productos</p>
      </div>
    </footer>
  </div>
</template>

<style lang="scss">
@use '@/styles/app';
@use '@/styles/views/login';
@use '@/styles/components/buttons';
</style>
