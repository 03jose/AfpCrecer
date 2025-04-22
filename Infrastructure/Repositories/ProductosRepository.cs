using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Infraestructure.Data;
using PruebaTecnica.Domain.DTOs;
using System.Data;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public class ProductoRepository : IProductosRepository
    {
        private readonly DefaultDbContext _context;
        public ProductoRepository(DefaultDbContext context) {
            _context = context;
        }

        public async Task<bool> CreateProducto(Productos Producto)
        {
            _context.Producto.Add(Producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var Producto = await _context.Producto.FindAsync(id);
            if (Producto != null)
            {
                _context.Producto.Remove(Producto);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Productos?> GetProductoById(int id)
        {
            return await _context.Producto                
                .FirstOrDefaultAsync(a => a.ProductoId == id);
        }

        public async Task<List<Productos>> GetProductos()
        {
            var productos = await _context.Producto
                                           .FromSqlRaw("EXEC sp_Product_List")
                                           .ToListAsync();
            return productos;
        }

        public async Task<bool> UpdateProducto(Productos Producto)
        {
            _context.Producto.Update(Producto);
            _context.Entry(Producto).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
