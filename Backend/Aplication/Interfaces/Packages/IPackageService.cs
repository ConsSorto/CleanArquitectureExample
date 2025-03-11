

using Aplication.DTOs.Packages;

namespace Aplication.Interfaces.Packages
{
    public interface IPackageService
    {
        Task<IEnumerable<PackageResponseDTO>> GetAllAsync();
        Task<PackageResponseDTO?> GetByIdAsync(int id);
        Task<PackageResponseDTO> CreateAsync(PackageRequestDTO dto);
        Task<bool> UpdateAsync(int id, PackageRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
