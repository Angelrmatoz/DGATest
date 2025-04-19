import { defineStore } from 'pinia';
import { ref, computed } from 'vue';
import productService from '@/api/productService';
export const useProductStore = defineStore('products', () => {
    // Estado
    const products = ref([]);
    const isLoading = ref(false);
    const error = ref(null);
    const selectedProduct = ref(null);
    // Getters
    const getProductById = computed(() => {
        return (id) => products.value.find(product => product.id === id);
    });
    const totalProducts = computed(() => products.value.length);
    // Acciones
    async function fetchProducts() {
        isLoading.value = true;
        error.value = null;
        try {
            products.value = await productService.getAll();
        }
        catch (err) {
            error.value = err.message || 'Error al cargar los productos';
            console.error(error.value);
        }
        finally {
            isLoading.value = false;
        }
    }
    async function fetchProductById(id) {
        isLoading.value = true;
        error.value = null;
        try {
            selectedProduct.value = await productService.getById(id);
        }
        catch (err) {
            error.value = err.message || `Error al cargar el producto con ID ${id}`;
            console.error(error.value);
        }
        finally {
            isLoading.value = false;
        }
    }
    async function createProduct(product) {
        isLoading.value = true;
        error.value = null;
        try {
            const newProduct = await productService.create(product);
            products.value.push(newProduct);
            return newProduct;
        }
        catch (err) {
            error.value = err.message || 'Error al crear el producto';
            console.error(error.value);
            throw err;
        }
        finally {
            isLoading.value = false;
        }
    }
    async function updateProduct(product) {
        isLoading.value = true;
        error.value = null;
        try {
            const updatedProduct = await productService.update(product);
            const index = products.value.findIndex(p => p.id === product.id);
            if (index !== -1) {
                products.value[index] = updatedProduct;
            }
            return updatedProduct;
        }
        catch (err) {
            error.value = err.message || `Error al actualizar el producto con ID ${product.id}`;
            console.error(error.value);
            throw err;
        }
        finally {
            isLoading.value = false;
        }
    }
    async function deleteProduct(id) {
        isLoading.value = true;
        error.value = null;
        try {
            await productService.delete(id);
            products.value = products.value.filter(product => product.id !== id);
        }
        catch (err) {
            error.value = err.message || `Error al eliminar el producto con ID ${id}`;
            console.error(error.value);
            throw err;
        }
        finally {
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
