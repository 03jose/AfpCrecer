using PruebaTecnica.Application.Services;
using PruebaTecnica.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnica.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductoController(ProductoService ProductoService)
        {
            _productoService = ProductoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productoService.GetProductos();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productoService.GetProductoById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoDTO ProductoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _productoService.CreateProducto(ProductoDTO);

            return success
                ? Ok(new { message = "Producto creado correctamente" })
                : BadRequest(new { message = "Error al crear el Producto" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoDTO ProductoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _productoService.UpdateProducto(id, ProductoDTO);
            return result
                ? Ok(new { message = "Producto actualizado correctamente" })
                : NotFound(new { message = "Producto no encontrado" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productoService.DeleteProducto(id);
            return result
                ? Ok(new { message = "Producto eliminado correctamente" })
                : NotFound(new { message = "Producto no encontrado" });

        }
    }
}
