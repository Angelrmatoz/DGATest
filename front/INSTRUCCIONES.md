# Guía Completa de Configuración e Instalación

Esta guía detalla paso a paso cómo configurar y ejecutar el proyecto completo, incluyendo tanto el backend (.NET Core) como el frontend (Vue.js).

## Contenido

1. [Requisitos previos](#requisitos-previos)
2. [Configuración del Backend](#configuración-del-backend)
3. [Configuración del Frontend](#configuración-del-frontend)
4. [Ejecución del Proyecto](#ejecución-del-proyecto)
5. [Verificación del Funcionamiento](#verificación-del-funcionamiento)
6. [Solución de Problemas Comunes](#solución-de-problemas-comunes)
7. [Comandos Útiles para Desarrollo](#comandos-útiles-para-desarrollo)

## Requisitos Previos

Asegúrate de tener instalados los siguientes componentes:

### Para el Backend

- **.NET SDK 8.0** o superior - [Descargar](https://dotnet.microsoft.com/download)
- **SQLite** (incluido en el proyecto) o **SQL Server** - [Descargar SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- **Visual Studio** (opcional) o **Visual Studio Code** con extensiones para C# - [Descargar VS Code](https://code.visualstudio.com/)

### Para el Frontend

- **Node.js** (versión 18.x o superior) - [Descargar](https://nodejs.org/)
- **npm** (incluido con Node.js) o **yarn**
- **Visual Studio Code** con extensiones para Vue.js (recomendado)

## Configuración del Backend

### Paso 1: Restaurar Dependencias

1. Abre una terminal en la carpeta raíz del proyecto
2. Navega a la carpeta del backend:
   ```bash
   cd Backend
   ```
3. Restaura las dependencias:
   ```bash
   dotnet restore
   ```

### Paso 2: Configurar la Base de Datos

#### Opción 1: Usar SQLite (predeterminado para desarrollo)

No se requiere configuración adicional. La base de datos SQLite se creará automáticamente en `Backend/products.db` cuando inicie la aplicación.

#### Opción 2: Usar SQL Server

1. Asegúrate de que SQL Server esté instalado y en ejecución
2. En SQL Server Management Studio o Azure Data Studio, crea una base de datos llamada `ProductManagementDB`
3. Modifica el archivo `Backend/appsettings.json` para usar SQL Server:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=ProductManagementDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
   }
   ```
4. Si estás usando SQL Server Express, ajusta la cadena de conexión:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=ProductManagementDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
   }
   ```
5. Modifica `Backend/Program.cs` para usar SQL Server en lugar de SQLite:

   ```csharp
   // Comentar o eliminar esta línea:
   options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

   // Y agregar esta línea:
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
   ```

### Paso 3: Aplicar Migraciones (si es necesario)

Si has realizado cambios en el modelo de datos o estás configurando por primera vez:

1. Instala la herramienta de Entity Framework Core:
   ```bash
   dotnet tool install --global dotnet-ef
   ```
2. Aplica las migraciones existentes:
   ```bash
   dotnet ef database update
   ```

## Configuración del Frontend

### Paso 1: Instalar Dependencias

1. Abre una terminal en la carpeta raíz del proyecto
2. Instala todas las dependencias:
   ```bash
   npm install
   ```

### Paso 2: Configurar Entorno (opcional)

Si necesitas configurar variables de entorno personalizadas o cambiar la URL de la API:

1. Crea un archivo `.env.local` en la raíz del proyecto
2. Configura las variables necesarias:
   ```
   VITE_API_URL=http://localhost:5048/api
   ```

## Ejecución del Proyecto

Para una experiencia completa, debes ejecutar tanto el backend como el frontend.

### Ejecutar Backend

1. Abre una nueva terminal en la raíz del proyecto
2. Navega a la carpeta Backend:
   ```bash
   cd Backend
   ```
3. Ejecuta el servidor:
   ```bash
   dotnet run
   ```
4. El backend estará disponible en:
   - API: http://localhost:5048/api
   - Swagger: http://localhost:5048/swagger

### Ejecutar Frontend

1. Abre otra terminal en la raíz del proyecto
2. Inicia el servidor de desarrollo:
   ```bash
   npm run dev
   ```
3. El frontend estará disponible en: http://localhost:5173

## Verificación del Funcionamiento

Para asegurarte de que todo funciona correctamente:

### Verificar el Backend

1. Abre un navegador y navega a http://localhost:5048/swagger
2. Deberías ver la interfaz de Swagger con todos los endpoints disponibles
3. Prueba el endpoint GET `/api/products` para ver si devuelve datos

### Verificar el Frontend

1. Abre un navegador y navega a http://localhost:5173
2. Deberías ver la pantalla principal de la aplicación
3. Navega a la sección de Productos y verifica que se muestren los productos desde la API

## Solución de Problemas Comunes

### Problemas en el Backend

#### Error "Cannot find specified file" al iniciar el backend

- Asegúrate de estar en la carpeta `Backend` al ejecutar `dotnet run`
- Ejecuta `dotnet restore` para restaurar todas las dependencias

#### Error de conexión a la base de datos

- Verifica que la cadena de conexión sea correcta en `appsettings.json`
- Asegúrate de que SQL Server esté en ejecución (si estás usando SQL Server)
- Comprueba los permisos de acceso a la base de datos

#### Error al aplicar migraciones

- Elimina la base de datos existente si está corrupta
- Ejecuta `dotnet ef database update --verbose` para ver mensajes detallados

### Problemas en el Frontend

#### Error "Module not found" al iniciar el frontend

- Ejecuta `npm install` para asegurarte de que todas las dependencias están instaladas
- Verifica que no hay errores de sintaxis en tus archivos JavaScript/TypeScript

#### Error CORS al conectar con el backend

- Asegúrate de que el backend está en ejecución
- Verifica que el backend tiene configurado CORS para permitir solicitudes desde el frontend
- Confirma que la URL de la API configurada en el frontend es correcta

#### Cambios no reflejados en la interfaz

- Limpia la caché del navegador (Ctrl+F5 o Cmd+Shift+R)
- Reinicia el servidor de desarrollo (detén y vuelve a ejecutar `npm run dev`)

## Comandos Útiles para Desarrollo

### Backend

- **Crear nueva migración**: `dotnet ef migrations add [NombreMigración]`
- **Revertir última migración**: `dotnet ef migrations remove`
- **Aplicar migraciones**: `dotnet ef database update`
- **Ejecutar en modo observador**: `dotnet watch run`
- **Compilar sin ejecutar**: `dotnet build`
- **Ejecutar pruebas**: `dotnet test`

### Frontend

- **Iniciar servidor de desarrollo**: `npm run dev`
- **Compilar para producción**: `npm run build`
- **Ejecutar linting**: `npm run lint`
- **Ejecutar pruebas unitarias**: `npm run test:unit`
- **Compilar y previsualizar**: `npm run preview`
