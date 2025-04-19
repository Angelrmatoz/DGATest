import axios from 'axios';

// URL base para la API
const API_URL = import.meta.env.VITE_API_URL || 'http://localhost:5048/api';

// Crear instancia de axios
const apiClient = axios.create({
  baseURL: API_URL,
  headers: {
    'Content-type': 'application/json',
  },
});

// Interceptor para agregar el token de autorización (si lo implementamos después)
apiClient.interceptors.request.use(
  config => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

// Interceptor para manejar errores globalmente
apiClient.interceptors.response.use(
  response => {
    return response;
  },
  error => {
    // Aquí podríamos agregar lógica para manejar errores comunes (401, 403, etc.)
    console.error('API Error:', error);
    return Promise.reject(error);
  }
);

export default apiClient;

export { API_URL };
