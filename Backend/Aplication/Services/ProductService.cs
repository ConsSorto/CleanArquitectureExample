
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

        public async Task<IEnumerable<ProductResponseDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductResponseDTO { Id = p.Id, Name = p.Name });
        }
        public async Task<ProductResponseDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product is null ? null : new ProductResponseDTO { Id = product.Id, Name = product.Name };

        }
        public async Task<ProductResponseDTO> CreateAsync(ProductRequestDTO dto)
        {
            var product = new Domain.Entities.Product(dto.Name);
            await _productRepository.AddAsync(product);
            return new ProductResponseDTO { Id = product.Id, Name= product.Name };
        }

        public async Task<bool> UpdateAsync(int id, ProductRequestDTO dto)
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
