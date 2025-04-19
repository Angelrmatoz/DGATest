/**
 * Interfaz que define la estructura de un Producto en la aplicación
 */
export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    stock: number;
    createdAt?: string;
    updatedAt?: string;
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
