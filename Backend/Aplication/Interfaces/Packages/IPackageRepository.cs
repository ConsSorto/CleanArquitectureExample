
using Domain.AggregateRoots.Packages

namespace Aplication.Interfaces.Packages
{
    public interface IPackageRepository
    {
        Task<IEnumerable<Package>> GetAllAsync();
        Task<Package?> GetByIdAsync(int id);
        Task AddAsync(Package package);
        Task<bool> UpdateAsync(Package package);
        Task<bool> DeleteAsync(int id);

    }
}
