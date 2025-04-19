/**
 * Interfaz que define la estructura de un producto
 */
export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  stock: number;
  category: string;
  imageUrl?: string;
  createdAt: Date;
  updatedAt: Date;
}

export interface CreateProductDTO {
  name: string;
  description: string;
  price: number;
  stock: number;
}

export interface UpdateProductDTO extends Partial<CreateProductDTO> {
  id: number;
}
