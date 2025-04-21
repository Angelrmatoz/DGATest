import { defineStore } from 'pinia';
import apiClient from '@/api/axios';

export const useAuthStore = defineStore('auth', {
  state: () => ({
    token: localStorage.getItem('token') || '',
    user: null as null | { email: string; id: string },
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
        const id = response.data.id;
        const clientId = response.data.clientId || response.data.ClientId;
        if (token && id && clientId) {
          this.token = token;
          localStorage.setItem('token', token);
          this.user = { email, id };
          localStorage.setItem('userId', id);
          localStorage.setItem('clientId', clientId);
        } else {
          this.error = 'No se recibió token, id o clientId.';
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
      localStorage.removeItem('userId');
      localStorage.removeItem('clientId');
    },
  },
});
