PersonAPI-DotNet — Entrega Lab 1

Implementación de Monolito con patrón MVC y DAO
Stack: .NET 7 · MS SQL Server 2022 · REST · Swagger 3

Repositorio: personapi-dotnet — este README cubre configuración, compilación, despliegue local, script DDL/DML, endpoints y la lista de entregables del laboratorio.

1. Descripción

API + aplicación MVC para gestionar personas (CRUD).
Se implementa como monolito con separación de capas: Controllers (API + MVC), Repositories (DAO), Models/Entities y Data (DbContext). Además se expone documentación con Swagger.

Objetivo del laboratorio: crear endpoints REST y vistas MVC según el modelo de datos, documentar y entregar código, scripts y documento del laboratorio.

2. Entregables (lo que debes subir al repo y entregar)

URL y TAG del repositorio público (GitHub/GitLab/Bitbucket).

README.md con instrucciones de instalación, compilación y despliegue (este archivo).

Script DDL y DML (archivo .sql) para crear la base y poblarla.

Código fuente completo.

Documento del laboratorio (Portada, Marco conceptual, Diseño, Procedimiento, Conclusiones, Referencias).

Tag de la entrega (ej. v1.0-lab1).

3. Requisitos / Prerrequisitos

.NET SDK 7.x (instalado).

Visual Studio 2022 Community (recomendado) con workloads:

Desarrollo ASP.NET y web

Almacenamiento y procesamiento de datos

Plantillas de proyecto / .NET

Herramientas de Entity Framework

SQL Server 2019/2022 Express (modo básico) o instancia SQL Server accesible.

SQL Server Management Studio (SSMS) 18+ (opcional pero recomendado).

Git instalado y acceso a GitHub.

Nota: las instrucciones asumen Windows (PowerShell/Visual Studio). Para Linux/macOS usar dotnet CLI equivalentes.

4. Modelo de datos (tabla principal persona)

Basado en el lab y los logs, la tabla mínima es:
