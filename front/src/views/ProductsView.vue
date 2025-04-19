<template>
  <div class="products-view">
    <div class="container">
      <h1>Gestión de Productos</h1>

      <!-- 
        Vista condicional:
        - Muestra la lista de productos cuando no estamos en modo formulario
        - Pasa los productos del store como prop
        - Escucha eventos para editar, crear y eliminar productos
      -->
      <ProductList
        v-if="!showForm"
        :products="productStore.products"
        :isLoading="productStore.isLoading"
        :error="productStore.error"
        @edit-product="editProduct"
        @new-product="createProduct"
        @delete-product="deleteProduct"
      />

      <!-- 
        Muestra el formulario de producto cuando showForm es true 
        - Para edición: pasa el producto seleccionado
        - Para creación: pasa null
        - Gestiona el estado de carga y los eventos de envío y cancelación
      -->
      <ProductForm
        v-else
        :product="selectedProduct"
        :isSubmitting="productStore.isLoading"
        @submit="submitProduct"
        @cancel="cancelForm"
      />
    </div>
  </div>
</template>

<script setup lang="ts">
import ProductList from '@/components/products/ProductList.vue';
import ProductForm from '@/components/products/ProductForm.vue';
import useProductsView from '@/composables/useProductsView';

/**
 * Esta vista utiliza un composable para separar la lógica de la interfaz
 * El composable useProductsView proporciona:
 * - Estado y métodos para gestionar productos
 * - Integración con la store de productos
 * - Lógica para alternar entre el formulario y la lista
 */
const {
  productStore, // Store con estado y acciones para productos
  showForm, // Controla si se muestra el formulario o la lista
  selectedProduct, // Producto seleccionado para edición (null para creación)
  createProduct, // Función para iniciar creación de un nuevo producto
  editProduct, // Función para editar un producto existente
  deleteProduct, // Función para eliminar un producto
  submitProduct, // Función para procesar el envío del formulario
  cancelForm, // Función para cancelar la edición/creación
} = useProductsView();
</script>

<style lang="scss">
@use '@/styles/views/products-view.scss';
</style>
