using Aplication.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly BackendDBContext _context;

        public BranchOfficeRepository(BackendDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BranchOffice>> GetAllAsync()
        {
            return await _context.BranchOffices.ToListAsync();
        }

        public async Task<BranchOffice?> GetByIdAsync(int id)
        {
            return await _context.BranchOffices.FindAsync(id);
        }
        public async Task AddAsync(BranchOffice branchOffice)
        {
            _context.BranchOffices.Add(branchOffice);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(BranchOffice branchOffice)
        {
            _context.BranchOffices.Update(branchOffice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var branchOffice = await _context.BranchOffices.FindAsync(id);
            if (branchOffice is null) return false;

            _context.BranchOffices.Remove(branchOffice);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
