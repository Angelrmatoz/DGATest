import { ref, computed, watch } from 'vue';
import type { Product } from '@/types/Product';
import { saleService } from '@/api/saleService';

export function useSaleForm(products: Product[]) {
  const selectedProductId = ref<number | ''>('');
  const quantity = ref(1);
  const error = ref('');

  const selectedProduct = computed(() => products.find(p => p.id === selectedProductId.value));

  watch(selectedProductId, () => {
    quantity.value = 1;
    error.value = '';
  });

  async function handleSale(emit: (productId: number, quantity: number) => void) {
    if (!selectedProduct.value) {
      error.value = 'Selecciona un producto.';
      return;
    }
    if (quantity.value < 1 || quantity.value > selectedProduct.value.stock) {
      error.value = 'Cantidad inválida.';
      return;
    }
    try {
      await saleService.registerSaleProduct({
        productId: selectedProduct.value.id,
        quantity: quantity.value,
        price: selectedProduct.value.price,
      });
      emit(selectedProduct.value.id, quantity.value);
      error.value = '';
    } catch (e: any) {
      error.value = e.message || 'Error al registrar la venta.';
    }
  }

  function sellAll(emit: (productId: number, quantity: number) => void) {
    if (!selectedProduct.value) return;
    quantity.value = selectedProduct.value.stock;
    handleSale(emit);
  }

  return {
    selectedProductId,
    quantity,
    error,
    selectedProduct,
    handleSale,
    sellAll,
  };
}
