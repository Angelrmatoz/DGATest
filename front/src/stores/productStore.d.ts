import type { Product, CreateProductDTO, UpdateProductDTO } from '@/types/Product';
export declare const useProductStore: import("pinia").StoreDefinition<"products", Pick<{
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
    createProduct: (product: CreateProductDTO) => Promise<Product>;
    updateProduct: (product: UpdateProductDTO) => Promise<Product>;
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
    createProduct: (product: CreateProductDTO) => Promise<Product>;
    updateProduct: (product: UpdateProductDTO) => Promise<Product>;
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
    createProduct: (product: CreateProductDTO) => Promise<Product>;
    updateProduct: (product: UpdateProductDTO) => Promise<Product>;
    deleteProduct: (id: number) => Promise<void>;
}, "fetchProducts" | "fetchProductById" | "createProduct" | "updateProduct" | "deleteProduct">>;
