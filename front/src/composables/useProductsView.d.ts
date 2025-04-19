import type { Product } from '@/types/Product';
/**
 * Tipo para los datos del formulario de producto
 * Define la estructura de datos que se espera recibir del formulario
 */
type ProductFormData = {
    name: string;
    description: string;
    price: number;
    stock: number;
};
/**
 * Composable que gestiona la lógica de la vista de productos
 * Proporciona funcionalidades para:
 * - Listar productos
 * - Crear nuevos productos
 * - Editar productos existentes
 * - Eliminar productos
 * - Gestionar estados de la UI (formulario/lista)
 */
export default function useProductsView(): {
    productStore: import("pinia").Store<"products", Pick<{
        products: import("vue").Ref<{
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        }[], Product[] | {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        }[]>;
        isLoading: import("vue").Ref<boolean, boolean>;
        error: import("vue").Ref<string | null, string | null>;
        selectedProduct: import("vue").Ref<{
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | null, Product | {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | null>;
        getProductById: import("vue").ComputedRef<(id: number) => {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | undefined>;
        totalProducts: import("vue").ComputedRef<number>;
        fetchProducts: () => Promise<void>;
        fetchProductById: (id: number) => Promise<void>;
        createProduct: (product: import("@/types/Product").CreateProductDTO) => Promise<Product>;
        updateProduct: (product: import("@/types/Product").UpdateProductDTO) => Promise<Product>;
        deleteProduct: (id: number) => Promise<void>;
    }, "products" | "isLoading" | "error" | "selectedProduct">, Pick<{
        products: import("vue").Ref<{
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        }[], Product[] | {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        }[]>;
        isLoading: import("vue").Ref<boolean, boolean>;
        error: import("vue").Ref<string | null, string | null>;
        selectedProduct: import("vue").Ref<{
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | null, Product | {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | null>;
        getProductById: import("vue").ComputedRef<(id: number) => {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | undefined>;
        totalProducts: import("vue").ComputedRef<number>;
        fetchProducts: () => Promise<void>;
        fetchProductById: (id: number) => Promise<void>;
        createProduct: (product: import("@/types/Product").CreateProductDTO) => Promise<Product>;
        updateProduct: (product: import("@/types/Product").UpdateProductDTO) => Promise<Product>;
        deleteProduct: (id: number) => Promise<void>;
    }, "getProductById" | "totalProducts">, Pick<{
        products: import("vue").Ref<{
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        }[], Product[] | {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        }[]>;
        isLoading: import("vue").Ref<boolean, boolean>;
        error: import("vue").Ref<string | null, string | null>;
        selectedProduct: import("vue").Ref<{
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | null, Product | {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | null>;
        getProductById: import("vue").ComputedRef<(id: number) => {
            id: number;
            name: string;
            description: string;
            price: number;
            stock: number;
            createdAt?: string | undefined;
            updatedAt?: string | undefined;
        } | undefined>;
        totalProducts: import("vue").ComputedRef<number>;
        fetchProducts: () => Promise<void>;
        fetchProductById: (id: number) => Promise<void>;
        createProduct: (product: import("@/types/Product").CreateProductDTO) => Promise<Product>;
        updateProduct: (product: import("@/types/Product").UpdateProductDTO) => Promise<Product>;
        deleteProduct: (id: number) => Promise<void>;
    }, "fetchProducts" | "fetchProductById" | "createProduct" | "updateProduct" | "deleteProduct">>;
    showForm: import("vue").Ref<boolean, boolean>;
    selectedProduct: import("vue").Ref<{
        id: number;
        name: string;
        description: string;
        price: number;
        stock: number;
        createdAt?: string | undefined;
        updatedAt?: string | undefined;
    } | null, Product | {
        id: number;
        name: string;
        description: string;
        price: number;
        stock: number;
        createdAt?: string | undefined;
        updatedAt?: string | undefined;
    } | null>;
    loadProducts: () => Promise<void>;
    createProduct: () => void;
    editProduct: (id: number) => Promise<void>;
    deleteProduct: (id: number) => Promise<void>;
    submitProduct: (formData: ProductFormData) => Promise<void>;
    cancelForm: () => void;
};
export {};
