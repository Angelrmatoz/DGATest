import { ref } from 'vue';
import { storeToRefs } from 'pinia';
import { useAuthStore } from '@/stores/authStore';

/**
 * Composable para manejar la autenticación real del usuario usando Pinia y JWT
 */
export function useAuth() {
  const authStore = useAuthStore();
  const { token, user, loading, error } = storeToRefs(authStore);
  const email = ref('');
  const password = ref('');

  // Login real contra el backend
  const handleLogin = async () => {
    await authStore.login(email.value, password.value);
    // Si el login fue exitoso, puedes limpiar los campos
    if (token.value) {
      email.value = '';
      password.value = '';
    }
  };

  // Logout real
  const handleLogout = () => {
    authStore.logout();
  };

  return {
    isAuthenticated: token,
    user,
    email,
    password,
    loading,
    errorMessage: error,
    handleLogin,
    handleLogout,
  };
}
