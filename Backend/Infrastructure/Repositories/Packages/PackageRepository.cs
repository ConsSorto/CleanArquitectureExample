
using Aplication.Interfaces.Packages;
using Domain.AggregateRoots.Packages;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Packages
{
    public class PackageRepository : IPackageRepository
    {
        private readonly BackendDBContext _context;

        public PackageRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Package>> GetAllAsync()
        {
            return await _context.Packages
                .Include(p => p.Truck)
                .ThenInclude(t => t.Driver)
                .Include(p => p.Branch)
                .Include(p => p.State)
                .Include(p => p.UserCreate)
                .Include(p => p.UserReceive)
                .Include(p => p.Details)
                .ThenInclude(d => d.Product)
                .ToListAsync();
        }

        public async Task<Package?> GetByIdAsync(int id)
        {
            return await _context.Packages
                .Include(p => p.Truck)
                    .ThenInclude(t => t.Driver)
                .Include(p => p.Branch)
                .Include(p => p.State)
                .Include(p => p.UserCreate)
                .Include(p => p.UserReceive)
                .Include(p => p.Details)
                    .ThenInclude(d => d.Product)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Package package)
        {
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Package package)
        {
            _context.Packages.Update(package);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package is null) return false;

            _context.Packages.Remove(package);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
