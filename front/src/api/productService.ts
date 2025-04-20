import apiClient from './axios';
import { Product } from '../types/Product';
import { CreateProductDTO } from '../types/Product';

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
    const response = await apiClient.get('/Product/GetAll');
    return response.data;
  },

  /**
   * Obtener un producto por su ID
   * @param id - ID del producto
   * @returns Promise con el producto
   */
  getById: async (id: string | number): Promise<Product> => {
    const response = await apiClient.get(`/Product/GetById`, { params: { id } });
    return response.data;
  },

  /**
   * Crear un nuevo producto
   * @param product - Datos del nuevo producto
   * @returns Promise con el producto creado
   */
  create: async (product: CreateProductDTO): Promise<Product> => {
    const response = await apiClient.post('/Product/Save', {
      Name: product.name,
      Description: product.description,
      Price: product.price,
      Stock: product.stock,
    });
    return response.data;
  },

  /**
   * Actualizar un producto existente
   * @param id - ID del producto a actualizar
   * @param product - Datos del producto a actualizar
   * @returns Promise con el producto actualizado
   */
  update: async (id: string | number, product: Partial<CreateProductDTO>): Promise<Product> => {
    const response = await apiClient.put('/Product/Update', {
      Id: Number(id),
      Name: product.name,
      Description: product.description,
      Price: product.price,
      Stock: product.stock,
    });
    return response.data;
  },

  /**
   * Eliminar un producto
   * @param id - ID del producto a eliminar
   * @returns Promise con el resultado de la operación
   */
  delete: async (id: string | number): Promise<void> => {
    await apiClient.delete('/Product/Delete', { params: { id } });
  },
};
