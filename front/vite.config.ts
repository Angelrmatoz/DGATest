import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import vueDevTools from 'vite-plugin-vue-devtools';

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    vue({
      // Configuración específica de Vue para evitar problemas de compilación
      script: {
        defineModel: true,
        propsDestructure: true,
      },
    }),
    vueDevTools(),
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url)),
    },
  },
  build: {
    // Configuración para evitar archivos de output innecesarios
    sourcemap: false,
    outDir: 'dist',
    emptyOutDir: true,
  },
});
