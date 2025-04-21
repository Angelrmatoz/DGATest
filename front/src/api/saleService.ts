import apiClient from './axios';

export interface RegisterSaleProductDTO {
  salesId: number; // id de la venta (puede ser generado por el backend)
  productId: number;
  quantity: number;
  price: number;
}

export const saleService = {
  /**
   * Registra una venta de producto en la base de datos
   */
  async registerSaleProduct(data: Omit<RegisterSaleProductDTO, 'salesId'>): Promise<void> {
    // El backend puede generar el SalesId automáticamente o puedes pasarlo si ya tienes una venta creada
    await apiClient.post('/SaleProduct/Register', data);
  },
};
