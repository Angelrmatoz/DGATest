<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router';
import { useAuth } from '@/composables/useAuth';
import { ref } from 'vue';
import apiClient from '@/api/axios';

// Usar el composable para la lógica de autenticación

const { isAuthenticated, email, password, errorMessage, handleLogin, handleLogout } = useAuth();

// Estado para controlar si mostrar el formulario de registro o el de login

const showRegistrationForm = ref(false);

// Datos para el formulario de registro

const registrationData = ref({
  firstName: '',
  lastName: '',
  email: '',
  phoneNumber: '',
  password: '',
  confirmPassword: '',
});

// Mensaje de error para el registro
const registrationError = ref('');

// Función para cambiar al formulario de registro
const showRegister = () => {
  showRegistrationForm.value = true;
};

// Función para volver al formulario de login
const showLogin = () => {
  showRegistrationForm.value = false;
};

// Función para manejar el registro
const handleRegistration = async () => {

  // Validar que las contraseñas coincidan

  if (registrationData.value.password !== registrationData.value.confirmPassword) {
    registrationError.value = 'Las contraseñas no coinciden';
    return;
  }

  try {

    // Llamada real al endpoint de registro

    await apiClient.post('/Account/Register', {
      name: registrationData.value.firstName,
      lastName: registrationData.value.lastName,
      email: registrationData.value.email,
      userName: registrationData.value.email, // UserName igual al email
      phoneNumber: String(registrationData.value.phoneNumber), // Enviar como string
      password: registrationData.value.password,
    });
    registrationError.value = '';
    showRegistrationForm.value = false;

    // Reiniciar el formulario
    registrationData.value = {
      firstName: '',
      lastName: '',
      email: '',
      phoneNumber: '',
      password: '',
      confirmPassword: '',
    };
    alert('¡Registro exitoso! Ahora puedes iniciar sesión.');
  } catch (error: any) {
    // Mostrar todos los errores de validación del backend
    if (error.response?.data?.errors) {
      const errors = error.response.data.errors;
      registrationError.value = Object.values(errors).flat().join(' | ');
    } else {
      registrationError.value = error.response?.data?.error || 'Error al registrar usuario';
    }
  }
};
</script>

<template>
  <!-- Mostrar formulario de login si no está autenticado -->
  <div v-if="!isAuthenticated" class="login-container">
    <div class="login-card">
      <div class="login-logo">
        <img alt="Logo" src="@/assets/logo.svg" />
      </div>

      <h2 class="login-title">Sistema de Gestión</h2>

      <form v-if="!showRegistrationForm" @submit.prevent="handleLogin" class="login-form">
        <div class="form-group">
          <label for="email">Correo</label>
          <input id="email" v-model="email" type="text" required placeholder="Ingrese su correo electrónico" />
        </div>

        <div class="form-group">
          <label for="password">Contraseña</label>
          <input id="password" v-model="password" type="password" required placeholder="Ingrese su contraseña" />
        </div>

        <p v-if="errorMessage" class="error-message">{{ errorMessage }}</p>

        <button type="submit" class="login-button">Iniciar sesión</button>
        <button type="button" @click="showRegister" class="login-button">Registrarse</button>
      </form>

      <form v-else @submit.prevent="handleRegistration" class="registration-form">
        <h3 class="section-title">Información Personal</h3>

        <div class="form-group">
          <label for="firstName">Nombre</label>
          <input id="firstName" v-model="registrationData.firstName" type="text" required
            placeholder="Ingrese su nombre" />
        </div>

        <div class="form-group">
          <label for="lastName">Apellido</label>
          <input id="lastName" v-model="registrationData.lastName" type="text" required
            placeholder="Ingrese su apellido" />
        </div>

        <h3 class="section-title">Datos de Cuenta</h3>

        <div class="form-group">
          <label for="email">Correo electrónico</label>
          <input id="email" v-model="registrationData.email" type="email" required
            placeholder="Ingrese su correo electrónico" />
        </div>
        <div class="form-group">
          <label for="phoneNumber">Número telefónico</label>
          <input id="phoneNumber" v-model="registrationData.phoneNumber" type="number" required
            placeholder="Ingrese su número telefónico" />
        </div>

        <div class="form-group">
          <label for="regPassword">Contraseña</label>
          <input id="regPassword" v-model="registrationData.password" type="password" required
            placeholder="Ingrese su contraseña" />
        </div>

        <div class="form-group">
          <label for="confirmPassword">Confirmar Contraseña</label>
          <input id="confirmPassword" v-model="registrationData.confirmPassword" type="password" required
            placeholder="Confirme su contraseña" />
        </div>

        <p v-if="registrationError" class="error-message">{{ registrationError }}</p>

        <div class="form-actions">
          <button type="submit" class="registration-button">Registrarse</button>
        </div>

        <div class="registration-links">
          <p>¿Ya tienes una cuenta? <a href="#" @click.prevent="showLogin">Iniciar sesión</a></p>
        </div>
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
@use '@/styles/main.scss';
</style>
