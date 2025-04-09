# DGA Test

## Características principales
CRUD

## Tecnologías utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- AutoMapper

## Estructura del proyecto

Este proyecto sigue la arquitectura Onion Architecture y está organizado en múltiples proyectos y capas. A continuación, se detallan los principales proyectos y sus dependencias:

### DGAPrueba.Core.Application

Este proyecto contiene las interfaces, servicios, maps, dtos y lógica de negocio principal de la aplicación.

Dependencias:
- DGAPrueba.Core.Domain
- AutoMapper
- Microsoft.Extensions.DependencyInjection

### RealEstateApp.Core.Domain
Este proyecto contiene las entidades y settins de la app.

Dependencias:

### RealEstateApp.Infrastructure.Persistence

Este proyecto contiene la configuracion del contexto de la base de datos y migrations y repositorios

- DGAPrueba.Core.Application
- DGAPrueba.Core.Domain
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.Extensions.DependencyInjection.Abstractions
- Microsoft.Extensions.Options.ConfigurationExtensions

### RealEstateApp.Presentation.WebApi

Este proyecto contiene la API RESTful de la aplicación.

Dependencias:
- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Swashbuckle.AspNetCore
- DGAPrueba.Core.Application
- DGAPrueba.Core.Domain
- DGAPrueba.Infrastructure.Persistence

## Requisitos

- Visual Studio 2022 u otro IDE (o posterior)
- .NET Core 8.0
- SQL Server (o cualquier otra base de datos compatible con EF Core)

## Configuración

1. Clona este repositorio en tu máquina local.
2. Abre la solución en Visual Studio.
3. Configura la cadena de conexión a la base de datos en el archivo `appsettings.json`.
4. Configura la API como proyecto por default
5. Ejecuta las migraciones de Entity Framework Core para crear la base de datos: `Update-Database` (desde la Consola del Administrador de Paquetes de NuGet).
6. Ejecuta la aplicación.

## Licencia

Este proyecto está licenciado bajo la [Licencia MIT](LICENSE).
