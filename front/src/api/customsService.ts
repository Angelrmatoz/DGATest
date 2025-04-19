import apiClient from './axios';

export interface Customs {
  id: number;
  name: string;
  location: string;
  country: string;
  email?: string;
  phone?: string;
  operationHours?: string;
  createdAt: Date;
  updatedAt: Date;
}

export const CustomsService = {
  // Obtener todas las aduanas
  getAll: async (): Promise<Customs[]> => {
    const response = await apiClient.get('/customs');
    return response.data;
  },

  // Obtener una aduana por ID
  getById: async (id: string): Promise<Customs> => {
    const response = await apiClient.get(`/customs/${id}`);
    return response.data;
  },

  // Crear una nueva aduana
  create: async (customs: Omit<Customs, 'id' | 'createdAt' | 'updatedAt'>): Promise<Customs> => {
    const response = await apiClient.post('/customs', customs);
    return response.data;
  },

  // Actualizar una aduana existente
  update: async (
    id: string,
    customs: Partial<Omit<Customs, 'id' | 'createdAt' | 'updatedAt'>>
  ): Promise<Customs> => {
    const response = await apiClient.put(`/customs/${id}`, customs);
    return response.data;
  },

  // Eliminar una aduana
  delete: async (id: string): Promise<void> => {
    await apiClient.delete(`/customs/${id}`);
  },
};
