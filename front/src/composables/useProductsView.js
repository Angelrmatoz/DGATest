import { ref, onMounted } from 'vue';
import { useProductStore } from '@/stores/productStore';
/**
 * Composable que gestiona la lógica de la vista de productos
 * Proporciona funcionalidades para:
 * - Listar productos
 * - Crear nuevos productos
 * - Editar productos existentes
 * - Eliminar productos
 * - Gestionar estados de la UI (formulario/lista)
 */
export default function useProductsView() {
    // Acceso al store de productos que contiene el estado global
    const productStore = useProductStore();
    // Estado local para controlar la UI
    const showForm = ref(false); // Controla si se muestra el formulario
    const selectedProduct = ref(null); // Producto seleccionado para edición
    // Cargar productos automáticamente al montar el componente
    onMounted(() => {
        loadProducts();
    });
    /**
     * Carga la lista de productos desde la API
     */
    async function loadProducts() {
        await productStore.fetchProducts();
    }
    /**
     * Inicia el proceso de creación de un nuevo producto
     * Resetea el producto seleccionado y muestra el formulario
     */
    function createProduct() {
        selectedProduct.value = null; // Indica que es un nuevo producto
        showForm.value = true; // Muestra el formulario
    }
    /**
     * Inicia el proceso de edición de un producto existente
     * Carga los datos del producto y muestra el formulario
     * @param id - ID del producto a editar
     */
    async function editProduct(id) {
        await productStore.fetchProductById(id); // Obtiene detalles del producto
        selectedProduct.value = productStore.selectedProduct; // Asigna el producto seleccionado
        showForm.value = true; // Muestra el formulario
    }
    /**
     * Elimina un producto después de confirmación
     * @param id - ID del producto a eliminar
     */
    async function deleteProduct(id) {
        try {
            await productStore.deleteProduct(id);
            // Opcional: mostrar mensaje de éxito
        }
        catch {
            // Ya manejado en el store
        }
    }
    /**
     * Procesa el envío del formulario de producto
     * Determina si se debe crear un nuevo producto o actualizar uno existente
     * @param formData - Datos del formulario validados
     */
    async function submitProduct(formData) {
        try {
            if (selectedProduct.value) {
                // Actualizar producto existente
                await productStore.updateProduct({
                    id: selectedProduct.value.id, // Incluimos el ID del producto existente
                    ...formData, // Extendemos con los datos del formulario
                });
            }
            else {
                // Crear nuevo producto
                await productStore.createProduct(formData);
            }
            // Después del éxito: volver a la vista de lista
            showForm.value = false;
            selectedProduct.value = null;
            // Opcional: mostrar mensaje de éxito
        }
        catch {
            // Ya manejado en el store
        }
    }
    /**
     * Cancela la edición/creación y vuelve a la vista de lista
     * Resetea el estado local
     */
    function cancelForm() {
        showForm.value = false;
        selectedProduct.value = null;
    }
    // Expone las propiedades y métodos para usar en el componente
    return {
        productStore, // Store de productos
        showForm, // Estado de visualización del formulario
        selectedProduct, // Producto seleccionado para edición (o null)
        loadProducts, // Método para cargar productos
        createProduct, // Método para iniciar creación
        editProduct, // Método para iniciar edición
        deleteProduct, // Método para eliminar
        submitProduct, // Método para procesar formulario
        cancelForm, // Método para cancelar
    };
}
