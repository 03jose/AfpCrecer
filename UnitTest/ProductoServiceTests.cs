using Xunit;
using Moq;
using System.Threading.Tasks;
using PruebaTecnica.Application.Services;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.DTOs;
using PruebaTecnica.Domain.Interfaces;
using AutoMapper;

namespace PruebaTecnica.Tests
{
    public class ProductoServiceTests
    {
        [Fact]
        public async Task CreateProducto_RetornaTRUE_CuandoEsSucceeds()
        {
            try
            {
                // Arrange
                var productoDTO = new ProductoDTO
                {
                    Nombre = "Producto Prueba",
                    Descripcion = "Test Desc",
                    Precio = 99.99m
                };

                var productoEntidad = new Productos
                {
                    Nombre = "Producto Prueba",
                    Descripcion = "Test Desc",
                    Precio = 99.99m
                };

                var mockRepo = new Mock<IProductosRepository>();
                var mockMapper = new Mock<IMapper>();

                mockMapper.Setup(m => m.Map<Productos>(It.IsAny<ProductoDTO>()))
                          .Returns(productoEntidad);

                mockRepo.Setup(r => r.CreateProducto(It.IsAny<Productos>()))
                        .ReturnsAsync(true);

                var service = new ProductoService(mockMapper.Object, mockRepo.Object);

                // Act
                var result = await service.CreateProducto(productoDTO);

                // Assert
                Assert.True(result);
                mockMapper.Verify(m => m.Map<Productos>(productoDTO), Times.Once);
                mockRepo.Verify(r => r.CreateProducto(productoEntidad), Times.Once);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Test failed with exception: {ex.Message}");
            }
        }

    }
}
