using Domain.Common;

namespace Aplication.Interfaces
{
    public interface IRepository<T> where T : EntityCatalog
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
