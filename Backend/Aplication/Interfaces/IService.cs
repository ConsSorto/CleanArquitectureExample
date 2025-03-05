using Domain.Common;
using Aplication.DTOs;

namespace Aplication.Interfaces
{
    public interface IService<T, TRequestDTO, TResponseDTO>
        where T : EntityCatalog
        where TRequestDTO : CatalogRequestDTO
        where TResponseDTO : CatalogResponseDTO
    {
        Task<IEnumerable<TResponseDTO>> GetAllAsync();
        Task<TResponseDTO?> GetByIdAsync(int id);
        Task<TResponseDTO> CreateAsync(TRequestDTO dto);
        Task<bool> UpdateAsync(int id, TRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
