using AutoMapper;
using PruebaTecnica.Domain.DTOs;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.Services
{
    public class ProductoService 
    {
        private readonly IProductosRepository _productosRepository;
        private readonly IMapper _mapper;
        public ProductoService( IMapper mapper, IProductosRepository productosRepository)
        {
            _mapper = mapper;
            _productosRepository = productosRepository;
        }
        public async Task<bool> CreateProducto(ProductoDTO productoDTO)
        {
            var productoEntity = _mapper.Map<Productos>(productoDTO);
            return await _productosRepository.CreateProducto(productoEntity);
        }
        public async Task<bool> DeleteProducto(int id)
        {
            await _productosRepository.DeleteProducto(id);
            return true;
        }
        public async Task<ProductoDTO?> GetProductoById(int id)
        {
            var aporte = await _productosRepository.GetProductoById(id);
            return aporte == null ?  null : _mapper.Map<ProductoDTO>(aporte);
        }
        public async Task<IEnumerable<ProductoDTO>> GetProductos()
        {
            var aportes = await _productosRepository.GetProductos();
            return _mapper.Map<IEnumerable<ProductoDTO>>(aportes);
        }
        public async Task<bool> UpdateProducto(int id, ProductoDTO productoDTO)
        {
            var existe = await _productosRepository.GetProductoById(id);
            if (existe == null)
            {
                return false;
            }

            return await _productosRepository.UpdateProducto(_mapper.Map<Productos>(productoDTO));
        }
    }
}
