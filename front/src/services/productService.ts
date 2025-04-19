import apiClient from '../api/axios';
import { Product } from '../types/Product';

/**
 * Servicio para gestionar operaciones CRUD de productos
 */
const productService = {
  /**
   * Obtiene todos los productos
   */
  getAll: async (): Promise<Product[]> => {
    const response = await apiClient.get('/products');
    return response.data;
  },

  /**
   * Obtiene un producto por su ID
   */
  getById: async (id: number): Promise<Product> => {
    const response = await apiClient.get(`/products/${id}`);
    return response.data;
  },

  /**
   * Crea un nuevo producto
   */
  create: async (product: Omit<Product, 'id' | 'createdAt' | 'updatedAt'>): Promise<Product> => {
    const response = await apiClient.post('/products', product);
    return response.data;
  },

  /**
   * Actualiza un producto existente
   */
  update: async (
    id: number,
    product: Partial<Omit<Product, 'id' | 'createdAt' | 'updatedAt'>>
  ): Promise<Product> => {
    const response = await apiClient.put(`/products/${id}`, product);
    return response.data;
  },

  /**
   * Elimina un producto por su ID
   */
  delete: async (id: number): Promise<void> => {
    await apiClient.delete(`/products/${id}`);
  },

  /**
   * Busca productos por categoría
   */
  getByCategory: async (category: string): Promise<Product[]> => {
    const response = await apiClient.get(`/products/category/${category}`);
    return response.data;
  },
};

export default productService;
