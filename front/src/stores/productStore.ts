import { defineStore } from 'pinia';
import { ref, computed } from 'vue';
import type { Product, CreateProductDTO, UpdateProductDTO } from '@/types/Product';
import { ProductService } from '@/api/productService';

export const useProductStore = defineStore('products', () => {
  // Estado
  const products = ref<Product[]>([]);
  const isLoading = ref(false);
  const error = ref<string | null>(null);
  const selectedProduct = ref<Product | null>(null);

  // Getters
  const getProductById = computed(() => {
    return (id: number) => products.value.find(product => product.id === id);
  });

  const totalProducts = computed(() => products.value.length);

  // Acciones
  async function fetchProducts() {
    isLoading.value = true;
    error.value = null;

    try {
      console.log('Fetching products from API...');
      products.value = await ProductService.getAll();
      console.log('Products fetched successfully:', products.value);
    } catch (err: unknown) {
      const errorMessage = err instanceof Error ? err.message : 'Error al cargar los productos';
      error.value = errorMessage;
      console.error('Error fetching products:', error.value, err);
    } finally {
      isLoading.value = false;
    }
  }

  async function fetchProductById(id: number) {
    isLoading.value = true;
    error.value = null;

    try {
      console.log(`Fetching product with ID ${id}...`);
      selectedProduct.value = await ProductService.getById(id.toString());
      console.log('Product fetched successfully:', selectedProduct.value);
    } catch (err: unknown) {
      const errorMessage =
        err instanceof Error ? err.message : `Error al cargar el producto con ID ${id}`;
      error.value = errorMessage;
      console.error(`Error fetching product with ID ${id}:`, error.value, err);
    } finally {
      isLoading.value = false;
    }
  }

  async function createProduct(product: CreateProductDTO) {
    isLoading.value = true;
    error.value = null;

    try {
      console.log('Creating new product:', product);
      const newProduct = await ProductService.create(product);
      products.value.push(newProduct);
      console.log('Product created successfully:', newProduct);
      return newProduct;
    } catch (err: unknown) {
      const errorMessage = err instanceof Error ? err.message : 'Error al crear el producto';
      error.value = errorMessage;
      console.error('Error creating product:', error.value, err);
      throw err;
    } finally {
      isLoading.value = false;
    }
  }

  async function updateProduct(product: UpdateProductDTO) {
    isLoading.value = true;
    error.value = null;

    try {
      console.log(`Updating product with ID ${product.id}:`, product);
      const updatedProduct = await ProductService.update(product.id.toString(), product);
      const index = products.value.findIndex(p => p.id === product.id);

      if (index !== -1) {
        products.value[index] = updatedProduct;
        console.log('Product updated successfully:', updatedProduct);
      }

      return updatedProduct;
    } catch (err: unknown) {
      const errorMessage =
        err instanceof Error ? err.message : `Error al actualizar el producto con ID ${product.id}`;
      error.value = errorMessage;
      console.error(`Error updating product with ID ${product.id}:`, error.value, err);
      throw err;
    } finally {
      isLoading.value = false;
    }
  }

  async function deleteProduct(id: number) {
    isLoading.value = true;
    error.value = null;

    try {
      console.log(`Deleting product with ID ${id}...`);
      await ProductService.delete(id.toString());
      products.value = products.value.filter(product => product.id !== id);
      console.log(`Product with ID ${id} deleted successfully`);
    } catch (err: unknown) {
      const errorMessage =
        err instanceof Error ? err.message : `Error al eliminar el producto con ID ${id}`;
      error.value = errorMessage;
      console.error(`Error deleting product with ID ${id}:`, error.value, err);
      throw err;
    } finally {
      isLoading.value = false;
    }
  }

  return {
    // Estado
    products,
    isLoading,
    error,
    selectedProduct,
    // Getters
    getProductById,
    totalProducts,
    // Acciones
    fetchProducts,
    fetchProductById,
    createProduct,
    updateProduct,
    deleteProduct,
  };
});
