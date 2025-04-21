import apiClient from './axios';

export interface RegisterSaleProductDTO {
  productId: number;
  quantity: number;
  price: number;
}

export interface SaleProduct {
  productId: number;
  quantity: number;
  price: number;
}

export interface RegisterSaleDTO {
  date: string; // formato YYYY-MM-DD
  total: number;
  clientId: number;
  products: SaleProduct[];
}

export const saleService = {
  /**
   * Registra una venta en la base de datos
   */
  async registerSale(data: RegisterSaleDTO): Promise<void> {
    await apiClient.post('/Sale/Save', data);
  },
};
