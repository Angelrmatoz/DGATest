# Sistema de Gestión de Aduanas (DGA Test)

Este proyecto es una solución completa para la gestión de productos, ventas y clientes, desarrollada con .NET Core en el backend y Vue.js en el frontend. Permite administrar inventario, registrar ventas, gestionar clientes y usuarios, y cuenta con autenticación segura.

## Características principales

- CRUD de productos, clientes y ventas
- Autenticación y autorización de usuarios
- Control de stock en tiempo real
- Registro de ventas asociadas a clientes
- Interfaz moderna y responsiva
- Arquitectura limpia y escalable

## Tecnologías utilizadas

- **Backend:** ASP.NET Core 8, Entity Framework Core, SQL Server
- **Frontend:** Vue.js 3, TypeScript, Pinia, Axios, Vite
- **Otros:** AutoMapper, Swagger/OpenAPI, SCSS, ESLint/Prettier

## Estructura del proyecto

```
DGAPrueba.Core.Application/   # Lógica de negocio, servicios, DTOs
DGAPrueba.Core.Domain/        # Entidades de dominio
DGAPrueba.Infrastructure.Persistence/ # Acceso a datos y migraciones
DGAPrueba.Presentation.Api/   # API RESTful
front/                        # Frontend Vue.js
```

## Requisitos previos

- Visual Studio 2022 o VS Code
- .NET SDK 8.0 o superior
- Node.js 18.x o superior
- npm o yarn
- SQL Server (o SQLite para pruebas)

## Instalación y configuración

### Backend

1. Clona este repositorio en tu máquina local.
2. Abre la solución en Visual Studio o VS Code.
3. Configura la cadena de conexión a la base de datos en `DGAPrueba.Presentation.Api/appsettings.json`.
4. Abre una terminal en la carpeta del backend y ejecuta:
   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   ```
5. La API estará disponible en `http://localhost:5219` (o el puerto configurado).

### Frontend

1. Abre una terminal en la carpeta `front`.
2. Instala las dependencias:
   ```bash
   npm install
   ```
3. Inicia el servidor de desarrollo:
   ```bash
   npm run dev
   ```
4. Accede a la app en `http://localhost:5173`.

## Primeros pasos

1. Regístrate como usuario desde la pantalla de login.
2. Inicia sesión con tu cuenta.
3. Crea productos y clientes desde la interfaz.
4. Registra ventas asociando productos y clientes.
5. Consulta el inventario y el historial de ventas.

## Buenas prácticas y soporte

- El código sigue principios de arquitectura limpia y separación de capas.
- Usa DTOs para transferir datos entre frontend y backend.
- El frontend es reactivo y fácil de extender.
- Para dudas o soporte, abre un issue en el repositorio.

## Licencia

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE).
