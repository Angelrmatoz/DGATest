import axios from 'axios';

/**
 * Cliente Axios configurado para realizar peticiones a la API
 */
const apiClient = axios.create({
  baseURL: 'http://localhost:5219/api', // URL base de la API de tu compañero
  headers: {
    'Content-Type': 'application/json',
  },
  // No es necesario enviar credenciales para esta API simple
  withCredentials: false,
});

// Interceptor para agregar el token JWT si existe
apiClient.interceptors.request.use(
  config => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers = config.headers || {};
      config.headers['Authorization'] = `Bearer ${token}`;
    }
    return config;
  },
  error => Promise.reject(error)
);

// Interceptor para manejar errores globalmente
apiClient.interceptors.response.use(
  response => response,
  error => {
    const { response } = error;
    console.log('Error completo:', error); // Agregar log detallado del error
    if (response && response.status >= 400) {
      console.error('Error en la petición:', response.data);
    } else if (!response) {
      console.error('Error de red o servidor no disponible');
    }
    return Promise.reject(error);
  }
);

export default apiClient;
