import apiClient from './axios';
import { Product } from '../types/Product';

// Importamos el tipo CreateProductDTO desde el archivo de tipos
import { CreateProductDTO } from '../types/Product';

// Tipo para actualizar productos
export type UpdateProductDTO = Partial<CreateProductDTO> & { id: number };

/**
 * Servicio para manejar las operaciones CRUD de productos
 * Integración con SQL Server a través de una API REST
 */
export const ProductService = {
  /**
   * Obtener todos los productos
   * @returns Promise con un array de productos
   */
  getAll: async (): Promise<Product[]> => {
    const response = await apiClient.get('/products');
    return response.data;
  },

  /**
   * Obtener un producto por su ID
   * @param id - ID del producto
   * @returns Promise con el producto
   */
  getById: async (id: string): Promise<Product> => {
    const response = await apiClient.get(`/products/${id}`);
    return response.data;
  },

  /**
   * Crear un nuevo producto
   * @param product - Datos del nuevo producto
   * @returns Promise con el producto creado
   */
  create: async (product: CreateProductDTO): Promise<Product> => {
    const response = await apiClient.post('/products', product);
    return response.data;
  },

  /**
   * Actualizar un producto existente
   * @param id - ID del producto a actualizar
   * @param product - Datos del producto a actualizar
   * @returns Promise con el producto actualizado
   */
  update: async (id: string, product: Partial<CreateProductDTO>): Promise<Product> => {
    const response = await apiClient.put(`/products/${id}`, product);
    return response.data;
  },

  /**
   * Eliminar un producto
   * @param id - ID del producto a eliminar
   * @returns Promise con el resultado de la operación
   */
  delete: async (id: string): Promise<void> => {
    await apiClient.delete(`/products/${id}`);
  },
};
