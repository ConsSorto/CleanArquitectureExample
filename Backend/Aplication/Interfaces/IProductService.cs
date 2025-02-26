
using Aplication.DTOs;

namespace Aplication.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllAsync();
        Task<ProductResponseDTO> GetByIdAsync(int id);
        Task<ProductResponseDTO> CreateAsync(ProductRequestDTO dto);
        Task<bool> UpdateAsync(int id, ProductRequestDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}
