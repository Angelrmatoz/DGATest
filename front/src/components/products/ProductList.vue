<template>
  <div class="product-list">
    <!-- Cabecera con título y botón para crear nuevo producto -->
    <div class="product-list__header">
      <h2>Lista de Productos</h2>
      <button class="btn btn--primary" @click="$emit('new-product')">Nuevo Producto</button>
    </div>

    <!-- Estados de carga y errores -->
    <div v-if="isLoading" class="loading">Cargando productos...</div>

    <div v-else-if="error" class="error">
      {{ error }}
    </div>

    <!-- Mensaje cuando no hay productos -->
    <div v-else-if="products.length === 0" class="empty-state">No hay productos disponibles.</div>

    <!-- Cuadrícula de productos cuando hay datos disponibles -->
    <div v-else class="product-grid">
      <!-- Iteración sobre cada producto -->
      <div v-for="product in products" :key="product.id" class="product-card">
        <h3>{{ product.name }}</h3>
        <p class="description">{{ product.description }}</p>
        <div class="product-details">
          <p class="price"><strong>Precio:</strong> ${{ product.price.toFixed(2) }}</p>
          <p class="stock"><strong>Stock:</strong> {{ product.stock }}</p>
        </div>
        <div class="product-actions">
          <button class="btn btn--secondary" @click="$emit('edit-product', product.id)">
            Editar
          </button>
          <button class="btn btn--danger" @click="confirmDelete(product.id)">Eliminar</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import type { Product } from '../../types/Product';

// Definimos los eventos que puede emitir este componente
const emit = defineEmits<{
  (e: 'edit-product', id: number): void; // Evento para editar un producto
  (e: 'new-product'): void; // Evento para crear un nuevo producto
  (e: 'delete-product', id: number): void; // Evento para eliminar un producto
}>();

// Definimos las propiedades que recibe el componente
defineProps<{
  products: Product[]; // Array de productos a mostrar
  isLoading: boolean; // Indica si los datos están cargando
  error: string | null; // Mensaje de error, si existe
}>();

/**
 * Función para confirmar y manejar la eliminación de un producto
 * Muestra un diálogo de confirmación antes de emitir el evento
 * @param id - El ID del producto a eliminar
 */
function confirmDelete(id: number) {
  if (confirm('¿Estás seguro de que deseas eliminar este producto?')) {
    // Emitimos el evento para que el componente padre maneje la eliminación
    emit('delete-product', id);
  }
}
</script>

<style lang="scss" scoped>
@use '@/styles/variables' as *;
@use '@/styles/mixins' as *;

.product-list {
  width: 100%;

  &__header {
    // En móviles: formato columna con elementos centrados
    @include flex(column, center, center);
    gap: $spacing-md;
    margin-bottom: $spacing-lg;

    h2 {
      margin: 0;
      font-size: 2.2rem;
      color: $dark-color;
      text-align: center;
    }

    .btn {
      width: 100%;
      max-width: 25rem;
    }

    // En tablets y escritorio: formato fila con elementos separados
    @include respond-to(sm) {
      @include flex(row, space-between, center);
      margin-bottom: $spacing-md;

      h2 {
        text-align: left;
      }

      .btn {
        width: auto;
      }
    }
  }

  // Estilos para los estados de carga, error y vacío
  .loading,
  .error,
  .empty-state {
    padding: $spacing-md;
    text-align: center;
  }

  .error {
    color: $danger-color;
  }

  // Cuadrícula de productos con diseño responsive
  .product-grid {
    display: grid;
    grid-template-columns: 1fr;
    gap: $spacing-md;

    // Diseño responsive que ajusta el número de columnas según el tamaño de pantalla
    @include respond-to(sm) {
      grid-template-columns: repeat(2, 1fr); // 2 columnas en pantallas pequeñas
    }

    @include respond-to(md) {
      grid-template-columns: repeat(3, 1fr); // 3 columnas en pantallas medianas
    }

    @include respond-to(lg) {
      grid-template-columns: repeat(4, 1fr); // 4 columnas en pantallas grandes
    }
  }

  // Estilos para cada tarjeta de producto
  .product-card {
    @include card;
    display: flex;
    flex-direction: column;

    h3 {
      margin-bottom: $spacing-sm;
      color: $primary-color;
    }

    .description {
      margin-bottom: $spacing-md;
      color: $secondary-color;
      flex-grow: 1; // Permite que la descripción ocupe el espacio disponible
    }

    .product-details {
      margin-bottom: $spacing-md;

      .price {
        color: $dark-color;
        font-size: 1.8rem;
        margin-bottom: $spacing-xs;
      }

      .stock {
        color: $secondary-color;
      }
    }

    // Botones de acción para editar y eliminar
    .product-actions {
      @include flex(row, space-between, center);

      .btn {
        flex: 1;
        margin: 0 $spacing-xs;

        &:first-child {
          margin-left: 0;
        }

        &:last-child {
          margin-right: 0;
        }
      }
    }
  }
}
</style>
