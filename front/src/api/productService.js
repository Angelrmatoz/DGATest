import apiClient from './axios';
// Rutas correctas según el backend .NET
export default {
  /**
   * Obtiene todos los productos
   */
  async getAll() {
    const response = await apiClient.get('/Product/GetAll');
    return response.data;
  },
  /**
   * Obtiene un producto por su ID
   */
  async getById(id) {
    const response = await apiClient.get('/Product/GetById', { params: { id } });
    return response.data;
  },
  /**
   * Crea un nuevo producto
   */
  async create(product) {
    const response = await apiClient.post('/Product/Save', product);
    return response.data;
  },
  /**
   * Actualiza un producto existente
   */
  async update(id, product) {
    const response = await apiClient.put('/Product/Update', { product: { ...product, id: Number(id) } });
    return response.data;
  },
  /**
   * Elimina un producto
   */
  async delete(id) {
    await apiClient.delete('/Product/Delete', { params: { id } });
  },
};
