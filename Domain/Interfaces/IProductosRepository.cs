using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Domain.Interfaces
{
    public interface IProductosRepository
    {
        
        Task<List<Productos>> GetProductos();
        Task<Productos> GetProductoById(int id);
        Task<bool> CreateProducto(Productos aporte);
        Task<bool> UpdateProducto(Productos aporte);
        Task<bool> DeleteProducto(int id);
    }
}
