import { ref, onMounted } from 'vue';

/**
 * Composable para manejar la autenticación del usuario
 * @returns Objeto con estado y métodos para gestionar la autenticación
 */
export function useAuth() {
  // Estado para controlar la autenticación
  const isAuthenticated = ref(false);
  const username = ref('');
  const password = ref('');
  const errorMessage = ref('');

  // Verificar si ya hay una sesión guardada al cargar la página
  onMounted(() => {
    // Limpiamos cualquier sesión anterior para asegurar que siempre pase por login
    localStorage.removeItem('isAuthenticated');
    isAuthenticated.value = false;

    // Si quieres recuperar la sesión guardada, descomenta estas líneas:
    // const savedAuth = localStorage.getItem('isAuthenticated');
    // if (savedAuth === 'true') {
    //   isAuthenticated.value = true;
    // }
  });

  /**
   * Función para manejar el login
   * Valida las credenciales y guarda el estado de autenticación
   */
  const handleLogin = () => {
    if (username.value === 'admin' && password.value === '1234') {
      // Autenticación exitosa
      isAuthenticated.value = true;
      localStorage.setItem('isAuthenticated', 'true');
      errorMessage.value = '';
      // Limpiar campos
      username.value = '';
      password.value = '';
    } else {
      // Autenticación fallida
      errorMessage.value = 'Usuario o contraseña incorrectos';
    }
  };

  /**
   * Función para cerrar sesión
   * Elimina la autenticación y el estado guardado
   */
  const handleLogout = () => {
    isAuthenticated.value = false;
    localStorage.removeItem('isAuthenticated');
  };

  return {
    isAuthenticated,
    username,
    password,
    errorMessage,
    handleLogin,
    handleLogout,
  };
}
