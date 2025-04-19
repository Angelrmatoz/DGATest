# Sistema de Gestión de Productos y Ventas

## Descripción

Sistema de gestión empresarial desarrollado con .NET Core y Vue.js para la administración de productos, ventas y clientes. Esta solución proporciona una interfaz moderna y eficiente para la gestión integral de inventarios y seguimiento de operaciones comerciales.

## Tecnologías Utilizadas

### Backend

- **.NET Core 8.0**: Framework moderno y de alto rendimiento para desarrollo de APIs RESTful
- **Entity Framework Core**: ORM para acceso a datos y gestión de migraciones
- **SQLite**: Base de datos relacional liviana para desarrollo y pruebas
- **Swagger/OpenAPI**: Documentación interactiva de la API
- **xUnit**: Framework para pruebas unitarias y de integración

### Frontend

- **Vue.js 3**: Framework progresivo con Composition API para mayor flexibilidad y reusabilidad
- **TypeScript**: Tipado estático para desarrollo más robusto y mantenible
- **Pinia**: Gestor de estado centralizado con soporte para TypeScript
- **Axios**: Cliente HTTP para comunicación con API RESTful
- **Vite**: Bundler ultrarrápido para desarrollo moderno
- **SCSS**: Preprocesador CSS para estilos avanzados y mantenibles
- **ESLint + Prettier**: Herramientas para código consistente y limpio

## Arquitectura del Sistema

### Patrón de Arquitectura

El sistema sigue una arquitectura de capas clara y modular:

1. **Capa de Presentación**: Interfaz de usuario Vue.js con componentes reactivos
2. **Capa de Comunicación**: Servicios API con Axios para interacción con el backend
3. **Capa de Lógica de Negocio**: Controllers y Services en el backend
4. **Capa de Acceso a Datos**: Repositorios y Entity Framework Core
5. **Capa de Persistencia**: Base de datos SQLite (desarrollo) / SQL Server (producción)

### Flujo de Datos

```
Cliente Web ⟷ Servicios API (Frontend) ⟷ API REST (.NET) ⟷ Servicios de Dominio ⟷ Repositorios ⟷ Base de Datos
```

## Estructura del Proyecto

### Backend

```
Backend/
├── Controllers/         # Controladores de la API por dominio
│   ├── Products/        # Endpoints para gestión de productos
│   └── ...              # Otros dominios de la aplicación
├── Data/                # Configuración de acceso a datos
│   └── ApplicationDbContext.cs  # Contexto de Entity Framework
├── DTOs/                # Objetos de Transferencia de Datos
│   └── ProductDTO.cs    # DTOs para productos (Create, Update, Get)
├── Models/              # Entidades de dominio
│   └── Product.cs       # Modelo de producto con validaciones
├── Migrations/          # Migraciones de base de datos
├── Program.cs           # Punto de entrada y configuración
└── appsettings.json     # Configuraciones de la aplicación
```

### Frontend

```
src/
├── api/                 # Servicios para comunicación con el backend
│   ├── axios.ts         # Configuración de cliente HTTP
│   └── productService.ts  # Servicios específicos para productos
├── components/          # Componentes reutilizables de UI
│   ├── common/          # Componentes genéricos (botones, inputs, etc.)
│   └── products/        # Componentes específicos para productos
├── composables/         # Hooks personalizados para lógica reutilizable
├── router/              # Configuración de navegación
├── stores/              # Gestión de estado centralizado con Pinia
│   └── productStore.ts  # Estado global para productos
├── styles/              # Estilos SCSS organizados por contexto
├── types/               # Definiciones de tipos TypeScript
│   └── Product.ts       # Interfaces para productos
└── views/               # Páginas principales de la aplicación
    └── ProductsView.vue # Vista para gestión de productos
```

## Características Principales

### Gestión de Productos

- **CRUD Completo**: Creación, lectura, actualización y eliminación de productos
- **Validaciones**: Tanto en frontend como backend para garantizar integridad de datos
- **Imágenes**: Soporte para asociar imágenes a productos mediante URLs
- **Categorización**: Organización de productos por categorías
- **Inventario**: Control de existencias con actualización en tiempo real

### Manejo de Estado

- **Pinia Store**: Estado centralizado con acciones y getters tipados
- **Composables**: Lógica reutilizable separada en hooks (composables)
- **Reactivo**: Actualización en tiempo real de la interfaz al cambiar datos

### Seguridad e Integridad

- **Validación de Datos**: Validaciones robustas tanto en cliente como servidor
- **Manejo de Errores**: Captura y presentación clara de errores al usuario
- **Sanitización de Entradas**: Prevención de inyección de código malicioso
- **Logs**: Registro detallado de operaciones para auditoría

## Instalación y Configuración

### Requisitos Previos

- **.NET SDK 8.0** o superior
- **Node.js 18.x** o superior
- **npm** o **yarn**
- **SQLite** (desarrollo) o **SQL Server** (producción)

### Backend

1. Clonar el repositorio
2. Navegar a la carpeta Backend:
   ```bash
   cd Backend
   ```
3. Restaurar dependencias:
   ```bash
   dotnet restore
   ```
4. Ejecutar las migraciones para crear la base de datos:
   ```bash
   dotnet ef database update
   ```
5. Iniciar el servidor:
   ```bash
   dotnet run
   ```
   La API estará disponible en `http://localhost:5048`

### Frontend

1. Navegar a la raíz del proyecto:
   ```bash
   cd [raíz-del-proyecto]
   ```
2. Instalar dependencias:
   ```bash
   npm install
   ```
3. Iniciar el servidor de desarrollo:
   ```bash
   npm run dev
   ```
   La aplicación estará disponible en `http://localhost:5173`

## Buenas Prácticas Implementadas

### Patrones de Diseño

- **Repositorio**: Abstracción del acceso a datos
- **Inyección de Dependencias**: Acoplamiento flexible entre componentes
- **DTO**: Transferencia de datos entre capas de manera estructurada
- **Composition API**: Organización de lógica por funcionalidad en Vue

### Convenciones de Código

- **TypeScript Estricto**: Tipos explícitos para evitar errores en tiempo de ejecución
- **ESLint + Prettier**: Formato consistente y prácticas recomendadas
- **Nomenclatura Clara**: Nombres descriptivos para variables, funciones y clases
- **Documentación JSDoc/TSDoc**: Comentarios explicativos en código clave

### Optimizaciones

- **Lazy Loading**: Carga diferida de componentes para mejor rendimiento
- **Memoización**: Caché de resultados de operaciones costosas
- **Paginación**: Carga eficiente de datos en listas grandes
- **Debouncing**: Limitación de llamadas API en operaciones frecuentes (búsqueda)

## Gestión de Errores

El sistema implementa un enfoque estructurado para el manejo de errores:

1. **Frontend**: Interceptores Axios para captura y procesamiento uniforme de errores
2. **Backend**: Middleware de excepciones para respuestas HTTP consistentes
3. **Retroalimentación al Usuario**: Mensajes claros y acciones recomendadas
4. **Logging**: Registro detallado para diagnóstico y solución de problemas

## Extensibilidad y Futuras Mejoras

El proyecto está diseñado para facilitar la incorporación de nuevas funcionalidades:

- **Módulo de Ventas**: Registro y seguimiento de transacciones
- **Gestión de Clientes**: Base de datos de clientes y perfil de compras
- **Reportes y Analítica**: Visualización de datos empresariales clave
- **Multilenguaje**: Soporte para internacionalización
- **Autenticación y Autorización**: Sistema de roles y permisos

## Contribución

1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## Soporte y Contacto

Para preguntas, reportes de bugs o sugerencias, por favor abrir un issue en el repositorio o contactar al equipo de desarrollo.

## Licencia

Este proyecto está bajo la Licencia MIT. Consulta el archivo `LICENSE` para más detalles.
