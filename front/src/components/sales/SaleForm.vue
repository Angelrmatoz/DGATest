<template>
  <div v-if="visible" class="modal-overlay">
    <div class="modal sale-modal">
      <h2>Registrar Venta</h2>
      <form @submit.prevent="handleSale(emitSaleSuccess)">
        <div class="form-group">
          <label for="product">Producto</label>
          <select id="product" v-model="selectedProductId" required>
            <option value="" disabled>Selecciona un producto</option>
            <option v-for="product in products" :key="product.id" :value="product.id">
              {{ product.name }} (Stock: {{ product.stock }})
            </option>
          </select>
        </div>
        <div v-if="selectedProduct">
          <div class="form-group">
            <label for="quantity">Cantidad a vender</label>
            <input id="quantity" type="number" v-model.number="quantity" :min="1" :max="selectedProduct.stock"
              required />
          </div>
          <div class="form-actions">
            <button type="submit" class="btn btn--primary"
              :disabled="quantity < 1 || quantity > selectedProduct.stock">Vender</button>
            <button type="button" class="btn btn--danger" @click="sellAll(emitSaleSuccess)">Vender todo</button>
          </div>
        </div>
        <div v-if="error" class="error-message">{{ error }}</div>
      </form>
      <button class="modal-close" @click="$emit('close')">Cerrar</button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useSaleForm } from '@/composables/useSaleForm';
import type { Product } from '@/types/Product';
import { watch } from 'vue';

const props = defineProps<{
  visible: boolean;
  products: Product[];
}>();
const emit = defineEmits<{
  (e: 'close'): void;
  (e: 'sale-success', productId: number, quantity: number): void;
}>();

const {
  selectedProductId,
  quantity,
  error,
  selectedProduct,
  handleSale,
  sellAll,
} = useSaleForm(props.products);

function emitSaleSuccess(productId: number, quantity: number) {
  emit('sale-success', productId, quantity);
}

watch(
  () => props.visible,
  (visible: boolean) => {
    if (visible && props.products.length > 0) {
      selectedProductId.value = props.products[0].id;
    } else {
      selectedProductId.value = '';
    }
    quantity.value = 1;
    error.value = '';
  }
);
</script>
