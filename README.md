# AfpCrecer
AfpCrecer es un proyecto desarrollado con .NET Core 6 para gestionar productos en una tienda en línea. 
Este proyecto permite realizar operaciones como agregar, editar, eliminar productos y configurar precios de los productos.

## Funcionalidades

- Gestión de productos: agregar, editar y eliminar productos.
- Configuración de precios: asignar y actualizar precios base y con descuento para los productos.
- Base de datos en memoria para pruebas unitarias.

## Tecnologías

- **.NET Core 6**: Framework para el desarrollo de aplicaciones web.
- **Entity Framework Core**: ORM utilizado para la interacción con la base de datos.
- **InMemoryDatabase**: Usado para pruebas unitarias.
- **Moq**: Utilizado para crear objetos simulados en pruebas unitarias.

## Estructura del Proyecto
- Application/: Contiene la lógica de negocios y los servicios de la aplicación.
- Domain/: Define las entidades, DTOs y validadores.
- Infrastructure/: Contiene la configuración de la base de datos y las implementaciones de repositorios.
- UnitTest/: Contiene los tests unitarios del proyecto.

Clona este repositorio:
   ```bash
   git clone https://github.com/03jose/AfpCrecer.git 
