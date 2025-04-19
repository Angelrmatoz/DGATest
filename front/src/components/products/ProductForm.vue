<template>
  <div class="product-form">
    <!-- Título dinámico: muestra "Editar Producto" o "Nuevo Producto" según sea el caso -->
    <h2>{{ product?.id ? 'Editar Producto' : 'Nuevo Producto' }}</h2>

    <form @submit.prevent="handleSubmit">
      <!-- Campo de nombre del producto -->
      <div class="form-group">
        <label for="name">Nombre</label>
        <input
          id="name"
          v-model="form.name"
          type="text"
          required
          placeholder="Nombre del producto"
        />
        <!-- Mensaje de error para el nombre -->
        <div v-if="errors.name" class="error">{{ errors.name }}</div>
      </div>

      <!-- Campo de descripción del producto -->
      <div class="form-group">
        <label for="description">Descripción</label>
        <textarea
          id="description"
          v-model="form.description"
          rows="4"
          placeholder="Descripción del producto"
        ></textarea>
        <!-- Mensaje de error para la descripción -->
        <div v-if="errors.description" class="error">{{ errors.description }}</div>
      </div>

      <!-- Fila que contiene los campos de precio y stock -->
      <div class="form-row">
        <!-- Campo de precio -->
        <div class="form-group">
          <label for="price">Precio</label>
          <input
            id="price"
            v-model.number="form.price"
            type="number"
            step="0.01"
            min="0"
            required
            placeholder="0.00"
          />
          <!-- Mensaje de error para el precio -->
          <div v-if="errors.price" class="error">{{ errors.price }}</div>
        </div>

        <!-- Campo de stock -->
        <div class="form-group">
          <label for="stock">Stock</label>
          <input
            id="stock"
            v-model.number="form.stock"
            type="number"
            min="0"
            required
            placeholder="0"
          />
          <!-- Mensaje de error para el stock -->
          <div v-if="errors.stock" class="error">{{ errors.stock }}</div>
        </div>
      </div>

      <!-- Botones de acción: Cancelar y Crear/Actualizar -->
      <div class="form-actions">
        <button type="button" class="btn btn--cancel" @click="$emit('cancel')">Cancelar</button>
        <button type="submit" class="btn btn--primary" :disabled="isSubmitting">
          {{ product?.id ? 'Actualizar' : 'Crear' }} Producto
        </button>
      </div>
    </form>
  </div>
</template>

<script setup lang="ts">
import { reactive, watch } from 'vue';
import type { Product } from '../../types/Product';

/**
 * Props que recibe el componente:
 * - product: Producto a editar (null en caso de creación)
 * - isSubmitting: Indica si se está procesando el envío del formulario
 */
const props = defineProps<{
  product?: Product | null;
  isSubmitting?: boolean;
}>();

/**
 * Eventos que emite el componente:
 * - submit: Cuando se envía el formulario con los datos validados
 * - cancel: Cuando se cancela la edición/creación
 */
const emit = defineEmits<{
  (
    e: 'submit',
    formData: { name: string; description: string; price: number; stock: number }
  ): void;
  (e: 'cancel'): void;
}>();

// Estado reactivo del formulario
const form = reactive({
  name: '',
  description: '',
  price: 0,
  stock: 0,
});

// Estado reactivo para los mensajes de error de validación
const errors = reactive({
  name: '',
  description: '',
  price: '',
  stock: '',
});

/**
 * Observer que actualiza el formulario cuando cambia el producto
 * Importante para cargar los datos cuando se edita un producto existente
 */
watch(
  () => props.product,
  newProduct => {
    if (newProduct) {
      // Si hay un producto, cargamos sus datos en el formulario
      form.name = newProduct.name;
      form.description = newProduct.description;
      form.price = newProduct.price;
      form.stock = newProduct.stock;
    } else {
      // Si no hay producto (creación), reseteamos el formulario
      form.name = '';
      form.description = '';
      form.price = 0;
      form.stock = 0;
    }
  },
  { immediate: true } // Ejecutar inmediatamente al montar el componente
);

/**
 * Valida todos los campos del formulario
 * @returns {boolean} true si el formulario es válido, false si hay errores
 */
function validate() {
  let isValid = true;

  // Resetear mensajes de error previos
  errors.name = '';
  errors.description = '';
  errors.price = '';
  errors.stock = '';

  // Validación del nombre
  if (!form.name.trim()) {
    errors.name = 'El nombre es obligatorio';
    isValid = false;
  } else if (form.name.length > 100) {
    errors.name = 'El nombre no puede exceder los 100 caracteres';
    isValid = false;
  }

  // Validación de la descripción (opcional pero con longitud máxima)
  if (form.description.length > 500) {
    errors.description = 'La descripción no puede exceder los 500 caracteres';
    isValid = false;
  }

  // Validación del precio (no puede ser negativo)
  if (form.price < 0) {
    errors.price = 'El precio no puede ser negativo';
    isValid = false;
  }

  // Validación del stock (no puede ser negativo)
  if (form.stock < 0) {
    errors.stock = 'El stock no puede ser negativo';
    isValid = false;
  }

  return isValid;
}

/**
 * Maneja el envío del formulario
 * Valida los datos y emite el evento 'submit' si son válidos
 */
function handleSubmit() {
  if (validate()) {
    // Si la validación es exitosa, emitimos el evento con los datos
    emit('submit', {
      name: form.name,
      description: form.description,
      price: form.price,
      stock: form.stock,
    });
  }
}
</script>

<style lang="scss">
@use '@/styles/components/product-form.scss';
</style>
