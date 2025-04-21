<template>
  <div class="sales-view">
    <h1>Registrar Venta de Productos</h1>
    <div class="sales-list">
      <div v-for="product in products" :key="product.id" class="sales-product-card">
        <h3>{{ product.name }}</h3>
        <p>{{ product.description }}</p>
        <div class="sales-product-details">
          <span>Stock: {{ product.stock }}</span>
          <span>Precio: ${{ product.price.toFixed(2) }}</span>
        </div>
        <div class="sales-actions">
          <input type="number" v-model.number="quantities[product.id]" :min="1" :max="product.stock"
            :placeholder="'Cantidad (max ' + product.stock + ')'" class="sales-quantity-input" />
          <button class="btn btn--primary" :disabled="!canSell(product)"
            @click="sell(product, quantities[product.id])">Vender</button>
          <button class="btn btn--danger" :disabled="product.stock === 0" @click="sellAll(product)">Vender todo</button>
        </div>
        <div v-if="errors[product.id]" class="error-message">{{ errors[product.id] }}</div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import useSalesView from '@/composables/useSalesView';

const { products, quantities, errors, canSell, sell, sellAll } = useSalesView();
</script>

<style lang="scss" scoped>
@use '@/styles/views/sales';
</style>
