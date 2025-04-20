import { defineStore } from 'pinia';
import apiClient from '@/api/axios';

export const useAuthStore = defineStore('auth', {
  state: () => ({
    token: localStorage.getItem('token') || '',
    user: null as null | { email: string },
    loading: false,
    error: '',
  }),
  actions: {
    async login(email: string, password: string) {
      this.loading = true;
      this.error = '';
      try {
        const response = await apiClient.post('/Account/Login', {
          email,
          Password: password,
        });
        // El token viene en response.data.jwToken
        const token = response.data.jwToken;
        if (token) {
          this.token = token;
          localStorage.setItem('token', token);
          this.user = { email };
        } else {
          this.error = 'No se recibió token.';
        }
      } catch (err: any) {
        this.error = err.response?.data?.error || 'Error al iniciar sesión';
      } finally {
        this.loading = false;
      }
    },
    logout() {
      this.token = '';
      this.user = null;
      localStorage.removeItem('token');
    },
  },
});
