import { ref, computed } from 'vue';
import { useProductStore } from '@/stores/productStore';
import { saleService } from '@/api/saleService';
import type { Product } from '@/types/Product';

const productStore = useProductStore();
const products = computed(() => productStore.products);

// Estado para la cantidad a vender por producto
const quantities = ref<Record<number, number>>({});
const errors = ref<Record<number, string>>({});

function canSell(product: Product) {
  const qty = quantities.value[product.id];
  return product.stock > 0 && qty && qty > 0 && qty <= product.stock;
}

async function sell(product: Product, quantity: number) {
  errors.value[product.id] = '';
  if (!quantity || quantity < 1 || quantity > product.stock) {
    errors.value[product.id] = 'Cantidad inválida.';
    return;
  }
  try {
    // Obtener el clientId del usuario autenticado desde localStorage
    const clientId = localStorage.getItem('clientId');
    if (!clientId) {
      errors.value[product.id] = 'No se encontró el cliente autenticado.';
      return;
    }
    const today = new Date();
    const date = today.toISOString().split('T')[0];
    const total = product.price * quantity;
    await saleService.registerSale({
      date,
      total,
      clientId: Number(clientId),
      products: [
        {
          productId: product.id,
          quantity,
          price: product.price,
        },
      ],
    });
    productStore.products = productStore.products
      .map(p => (p.id === product.id ? { ...p, stock: p.stock - quantity } : p))
      .filter(p => p.stock > 0);
    quantities.value[product.id] = 1;
  } catch (e: any) {
    errors.value[product.id] = e.message || 'Error al registrar la venta.';
  }
}

function sellAll(product: Product) {
  if (product.stock > 0) {
    sell(product, product.stock);
  }
}

export default function useSalesView() {
  return {
    products,
    quantities,
    errors,
    canSell,
    sell,
    sellAll,
  };
}
