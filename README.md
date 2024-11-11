
# Prueba Técnica

Este repositorio contiene dos ejercicios en **ASP.NET Core** que utilizan Minimal APIs y Entity Framework Core.


**Requisitos**:
- **.NET 8**
- **SQL Server 2019**

## Ejercicios

### Ejercicio 1: Minimal API y Dependency Injection
API mínima con inyección de dependencias para un servicio de suma.
- **POST /api/calculate**: Recibe dos números y devuelve la suma.

### Ejercicio 2: API CRUD con SQL Server y Patrón de Repositorio
API para realizar operaciones CRUD en una tabla `Employees` en SQL Server.
- **POST /api/employees**: Crear empleado.
- **GET /api/employees**: Obtener empleados.
- **GET /api/employees/{id}**: Obtener empleado por ID.
- **PUT /api/employees/{id}**: Actualizar empleado.
- **DELETE /api/employees/{id}**: Eliminar empleado.

## Configuración Rápida

1. Crear la base de datos y la tabla `Employees` en SQL Server:

   Ejecutar las siguientes consultas SQL en tu instancia de SQL Server para crear la base de datos y la tabla necesarias:

   ```sql
   CREATE DATABASE CompanyDB;

   USE CompanyDB;

   CREATE TABLE Employees (
       EmployeeId INT PRIMARY KEY IDENTITY(1,1),
       FirstName NVARCHAR(50) NOT NULL,
       LastName NVARCHAR(50) NOT NULL,
       Salary DECIMAL(18, 2) NOT NULL
   );
   ```

2. Actualizar `appsettings.json` con la cadena de conexión local:
   ```json
   "ConnectionStrings": { "DefaultConnection": "Server=localhost;Database=CompanyDB;Trusted_Connection=True;" }
   ```
