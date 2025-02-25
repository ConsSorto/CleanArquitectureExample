
using Aplication.DTOs;
using Aplication.Interfaces;

namespace Aplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
        }

        Task<ProductDTO> IProductService.CreateAsync(ProductDTO dto)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProductService.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductDTO>> IProductService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<ProductDTO> IProductService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IProductService.UpdateAsync(int id, ProductDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
