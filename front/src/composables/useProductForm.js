import { reactive, watch } from 'vue';
export default function useProductForm(props, emit) {
    // Formulario reactivo
    const form = reactive({
        name: '',
        description: '',
        price: 0,
        stock: 0,
    });
    // Errores de validación
    const errors = reactive({
        name: '',
        description: '',
        price: '',
        stock: '',
    });
    // Cuando cambia el producto (para edición), actualizamos el formulario
    watch(() => props.product, newProduct => {
        if (newProduct) {
            form.name = newProduct.name;
            form.description = newProduct.description;
            form.price = newProduct.price;
            form.stock = newProduct.stock;
        }
        else {
            // Resetear formulario
            form.name = '';
            form.description = '';
            form.price = 0;
            form.stock = 0;
        }
    }, { immediate: true });
    // Validación del formulario
    function validate() {
        let isValid = true;
        // Resetear errores
        errors.name = '';
        errors.description = '';
        errors.price = '';
        errors.stock = '';
        // Validar nombre
        if (!form.name.trim()) {
            errors.name = 'El nombre es obligatorio';
            isValid = false;
        }
        else if (form.name.length > 100) {
            errors.name = 'El nombre no puede exceder los 100 caracteres';
            isValid = false;
        }
        // Validar descripción
        if (form.description.length > 500) {
            errors.description = 'La descripción no puede exceder los 500 caracteres';
            isValid = false;
        }
        // Validar precio
        if (form.price < 0) {
            errors.price = 'El precio no puede ser negativo';
            isValid = false;
        }
        // Validar stock
        if (form.stock < 0) {
            errors.stock = 'El stock no puede ser negativo';
            isValid = false;
        }
        return isValid;
    }
    // Envío del formulario
    function handleSubmit() {
        if (validate()) {
            emit('submit', {
                name: form.name,
                description: form.description,
                price: form.price,
                stock: form.stock,
            });
        }
    }
    // Cancelar formulario
    function handleCancel() {
        emit('cancel');
    }
    return {
        form,
        errors,
        validate,
        handleSubmit,
        handleCancel,
    };
}
