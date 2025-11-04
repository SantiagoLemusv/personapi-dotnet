# PersonAPI-DotNet

**Laboratorio 1 — Implementación de Monolito con patrón MVC y DAO**

**Stack:** .NET 7 · MS SQL Server 2022 · REST · Swagger 3

Repositorio: `personapi-dotnet`

Este README cubre: instalación, configuración, compilación, despliegue local, endpoints API, vistas MVC, scripts SQL, y referencias.

---

## 1. Descripción

API + aplicación web MVC para **gestión de personas** (CRUD).
Arquitectura: **monolito** con separación de capas:

* **Controllers:** API REST y vistas MVC
* **Repositories:** DAO para acceso a datos
* **Models/Entities:** clases de datos y DTOs
* **Data/DbContext:** contexto de Entity Framework Core

Se expone documentación Swagger para probar los endpoints.

**Objetivo del laboratorio:** implementar el CRUD completo, probar con base de datos SQL Server y entregar código, scripts y documentación.

---

## 2. Requisitos

* **Sistema operativo:** Windows (PowerShell)
* **.NET SDK:** 7.x
* **Visual Studio 2022 Community** con los siguientes workloads:

  * Desarrollo ASP.NET y web
  * Almacenamiento y procesamiento de datos
  * Plantillas de proyecto / .NET
  * Entity Framework Tools
* **SQL Server 2019/2022 Express**
* **SQL Server Management Studio 18+** (opcional, pero recomendado)
* **Git**

---

## 3. Entregables

1. Repositorio público (`GitHub/GitLab/Bitbucket`) con TAG de entrega (`v1.0-lab1`)
2. `README.md` con instrucciones completas
3. Scripts SQL (`scripts/persona_db.sql`) — DDL y DML
4. Código fuente completo (`Controllers/`, `Models/`, `Repositories/`, `Views/`, `Data/`)
5. Documento del laboratorio en PDF con:

   * Portada
   * Marco conceptual
   * Diseño (diagramas de entidad-relación y de capas)
   * Procedimiento
   * Conclusiones y lecciones aprendidas
   * Referencias

---

## 4. Modelo de datos (tabla `persona`)

**DDL:**

```sql
CREATE DATABASE persona_db;
GO
USE persona_db;
GO

CREATE TABLE persona (
    cc BIGINT NOT NULL PRIMARY KEY,
    nombre NVARCHAR(45) NULL,
    apellido NVARCHAR(45) NULL,
    genero NCHAR(1) NULL,  -- M/F/O
    edad INT NULL
);
GO
```

**DML ejemplo:**

```sql
INSERT INTO persona (cc, nombre, apellido, genero, edad)
VALUES
(111111111111111, N'Juan', N'Perez', 'M', 30),
(222222222222222, N'Maria', N'Gomez', 'F', 25);
GO
```

---

## 5. Estructura del proyecto

```
personapi-dotnet/
├─ Controllers/         # Controladores API y MVC
├─ Models/
│  └─ Entities/         # Entidades generadas por scaffold o manuales
├─ Repositories/        # DAO: IPersonRepository, PersonRepository
├─ Views/               # Vistas Razor (Index, Create, Edit, Details, Delete)
├─ Data/                # AppDbContext.cs
├─ wwwroot/             # Archivos estáticos
├─ scripts/             # persona_db.sql
├─ .gitignore
├─ README.md
└─ appsettings.json
```

---

## 6. Configuración y despliegue

### 6.1 Clonar repositorio

```bash
git clone https://github.com/TuUsuario/personapi-dotnet.git
cd personapi-dotnet/personapi-dotnet
```

### 6.2 Configurar SQL Server

* Crear la base `persona_db` o ejecutar `scripts/persona_db.sql`
* Asegurarse de que el usuario `sa` tenga permisos

### 6.3 Cadena de conexión (`appsettings.json`)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=persona_db;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### 6.4 Restaurar paquetes y compilación

```bash
dotnet restore
dotnet build
```

### 6.5 Scaffold Database-First (opcional)

```powershell
Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=persona_db;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/Entities
```

### 6.6 Code-First Migrations (opcional)

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 6.7 Ejecutar proyecto

```bash
dotnet run
```

Accede en: `http://localhost:{puerto}`
Swagger UI: `/swagger/index.html`

---

## 7. Endpoints API

| Método | Ruta               | Acción                 |
| ------ | ------------------ | ---------------------- |
| GET    | /api/Personas      | Listar personas        |
| GET    | /api/Personas/{cc} | Obtener persona por cc |
| POST   | /api/Personas      | Crear persona          |
| PUT    | /api/Personas/{cc} | Actualizar persona     |
| DELETE | /api/Personas/{cc} | Eliminar persona       |

**Ejemplo POST:**

```json
{
  "cc": 333333333333333,
  "nombre": "Luis",
  "apellido": "Martinez",
  "genero": "M",
  "edad": 28
}
```

---

## 8. Vistas MVC

| Ruta                   | Acción          |
| ---------------------- | --------------- |
| /Personas              | Index (listado) |
| /Personas/Create       | Crear           |
| /Personas/Edit/{cc}    | Editar          |
| /Personas/Details/{cc} | Ver detalles    |
| /Personas/Delete/{cc}  | Eliminar        |

---

## 9. Git y TAGs

```bash
# Tag de entrega
git tag -a v1.0-lab1 -m "Entrega laboratorio 1 - personapi-dotnet"
git push origin v1.0-lab1

# Subir cambios
git add .
git commit -m "Entrega Lab1: API + MVC, scripts y README"
git push origin main
```

---

## 10. Recursos y referencias

* [EF Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
* [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/)
* Tutoriales provistos por el laboratorio:

  * [Video 1](https://www.youtube.com/watch?v=6nT-RjMEG0o&ab_channel=hdeleon.net)
  * [Video 2](https://www.youtube.com/watch?v=28LjewDjaz4&ab_channel=hdeleon.net)
  * [Artículo Parte 1](https://dev.to/veronicaguamann/api-con-aspnet-mvc-6-y-sql-server-mediante-entity-framework-core-6-code-first-parte-1-2i05)
  * [Artículo Parte 2](https://dev.to/veronicaguamann/api-con-aspnet-mvc-6-y-sql-server-mediante-entity-framework-core-6-code-first-parte-2-4lbg)
  * [C# Corner: Web API con EF Core](https://www.c-sharpcorner.com/article/building-asp-net-web-api-in-net-core-with-entity-framework/)

---

## 11. Autor

**Santiago Lemus**
GitHub: [https://github.com/SantiagoLemusv](https://github.com/SantiagoLemusv)
