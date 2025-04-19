import apiClient from './axios';
const RESOURCE_URL = '/products';
export default {
    /**
     * Obtiene todos los productos
     */
    async getAll() {
        const response = await apiClient.get(RESOURCE_URL);
        return response.data;
    },
    /**
     * Obtiene un producto por su ID
     */
    async getById(id) {
        const response = await apiClient.get(`${RESOURCE_URL}/${id}`);
        return response.data;
    },
    /**
     * Crea un nuevo producto
     */
    async create(product) {
        const response = await apiClient.post(RESOURCE_URL, product);
        return response.data;
    },
    /**
     * Actualiza un producto existente
     */
    async update(id, product) {
        const response = await apiClient.put(`${RESOURCE_URL}/${id}`, product);
        return response.data;
    },
    /**
     * Elimina un producto
     */
    async delete(id) {
        await apiClient.delete(`${RESOURCE_URL}/${id}`);
    },
};
