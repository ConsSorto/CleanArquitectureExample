
using Aplication.DTOs;

namespace Aplication.Interfaces
{
    public interface IBranchOfficeService
    {
        Task<IEnumerable<BranchOfficeResponseDTO>> GetAllAsync();
        Task<BranchOfficeResponseDTO> GetByIdAsync(int id);
        Task<BranchOfficeResponseDTO> CreateAsync(BranchOfficeRequestDTO dto);
        Task<bool> UpdateAsync(int id, BranchOfficeRequestDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}
