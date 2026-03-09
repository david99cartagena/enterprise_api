# 📦 API REST – Gestión de Empresas y Códigos

API REST desarrollada en **ASP .NET Core** para la gestión de **empresas y códigos asociados**, permitiendo realizar operaciones CRUD parciales y consultas relacionadas entre entidades.

Este proyecto fue construido como parte de una **prueba técnica backend**, aplicando buenas prácticas de arquitectura y desarrollo en .NET.

## ⚙️ Stack Tecnológico

**Backend**

- ASP .NET Core 10
- Entity Framework Core
- PostgreSQL
- AutoMapper
- Swagger (Swashbuckle)

**Dependencias principales**

- AutoMapper.Extensions.Microsoft.DependencyInjection - 12.0.1
- Microsoft.EntityFrameworkCore - 10.0.3
- Microsoft.EntityFrameworkCore.Tools - 10.0.3
- Npgsql.EntityFrameworkCore.PostgreSQL - 10.0.0
- Swashbuckle.AspNetCore - 10.1.4

## 🧠 Arquitectura

El proyecto sigue una **separación por capas** para mejorar la mantenibilidad y el desacoplamiento.

```
Controller
   ↓
Service (lógica de negocio)
   ↓
Entity Framework / DbContext
   ↓
PostgreSQL
```

## 📁 Estructura del Proyecto

```
EnterpriseApi
│
├── Controllers
│   ├── CodeController.cs
│   └── EnterpriseController.cs
│
├── Services
│   ├── Interfaces
│   │   ├── ICodeService.cs
│   │   └── IEnterpriseService.cs
│   │
│   ├── CodeService.cs
│   └── EnterpriseService.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Models
│   ├── Code.cs
│   └── Enterprise.cs
│
├── DTOs
│   ├── code
│   │   ├── CodeReadDto.cs
│   │   ├── CreateCodeDto.cs
│   │   └── UpdateCodeDto.cs
│   │
│   └── enterprise
│       ├── EnterpriseReadDto.cs
│       ├── CreateEnterpriseDto.cs
│       └── UpdateEnterpriseDto.cs
│
├── Migrations
│
├── MappingProfile.cs
└── Program.cs
```

## 🗄️ Modelo de datos

### Enterprise

| Campo   | Tipo   | Descripción           |
| ------- | ------ | --------------------- |
| Id      | int    | Identificador         |
| Name    | string | Nombre de la empresa  |
| Nit     | string | Identificación fiscal |
| Address | string | Dirección             |

### Code

| Campo        | Tipo   | Descripción         |
| ------------ | ------ | ------------------- |
| Id           | int    | Identificador       |
| CodeValue    | string | Código asociado     |
| EnterpriseId | int    | Empresa relacionada |

## 📡 Endpoints

### Enterprise

| Método | Endpoint                  | Descripción            |
| ------ | ------------------------- | ---------------------- |
| GET    | /api/enterprise           | Listar empresas        |
| GET    | /api/enterprise/{id}      | Obtener empresa por ID |
| GET    | /api/enterprise/nit/{nit} | Buscar empresa por NIT |
| POST   | /api/enterprise           | Crear empresa          |
| PATCH  | /api/enterprise/{id}      | Actualizar empresa     |

### Code

| Método | Endpoint                            | Descripción                  |
| ------ | ----------------------------------- | ---------------------------- |
| GET    | /api/code/{id}                      | Obtener código por ID        |
| GET    | /api/code/enterprise/{enterpriseId} | Códigos de una empresa       |
| GET    | /api/code/{id}/enterprise           | Empresa asociada a un código |
| POST   | /api/code                           | Crear código                 |
| PATCH  | /api/code/{id}                      | Actualizar código            |

### 🛠️ Instalación y ejecución

1. **Clonar repositorio**

   ```bash
   git clone https://github.com/david99cartagena/enterprise_api.git
   ```

   ```bash
   cd enterprise_api
   ```

2. **Restaurar dependencias**

   ```bash
   dotnet restore
   ```

3. **Aplicar migraciones**
   ```bash
   dotnet ef database update
   ```
4. **Ejecutar la API**
   ```bash
   dotnet run
   ```

## 📘 Documentación

Swagger: http://localhost:5294/swagger/index.html

## 📸 Ejemplos de uso en Swagger

### Vista general de la API

![swagger](images/swagger_overview.png)

### Crear empresa

![swagger](images/create_enterprise.png)

### Crear código

![swagger](images/create_code.png)
