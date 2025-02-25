
using System.Xml;
using Aplication.DTOs;
using Aplication.Interfaces;

namespace Aplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDTO { Id = p.Id, Name = p.Name });
        }
        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product is null ? null : new ProductDTO { Id = product.Id, Name = product.Name };

        }
        public async Task<ProductDTO> CreateAsync(ProductDTO dto)
        {
            var product = new Domain.Entities.Product(dto.Name);
            await _productRepository.AddAsync(product);
            return new ProductDTO { Id = product.Id, Name= product.Name };
        }

        public async Task<bool> UpdateAsync(int id, ProductDTO dto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            
            if (product is null)
                return false;

            product.Name = dto.Name;
           
            return await _productRepository.UpdateAsync(product); 
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
