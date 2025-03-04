
using Domain.Entities;

namespace Aplication.Interfaces
{
    public interface IBranchOfficeRepository
    {
        Task<IEnumerable<BranchOffice>> GetAllAsync();
        Task<BranchOffice?> GetByIdAsync(int id);
        Task AddAsync(BranchOffice product);
        Task<bool> UpdateAsync(BranchOffice brachOffice);
        Task<bool> DeleteAsync(int id);

    }
}
