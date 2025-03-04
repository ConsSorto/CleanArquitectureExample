using Aplication.DTOs;
using Aplication.Interfaces;

namespace Aplication.Services
{
    public class BranchOfficeService : IBranchOfficeService
    {
        private readonly IBranchOfficeRepository _branchOfficeRepository;

        public BranchOfficeService(IBranchOfficeRepository branchOfficeRepository)
        {
            _branchOfficeRepository = branchOfficeRepository;
        }

        public async Task<IEnumerable<BranchOfficeResponseDTO>> GetAllAsync()
        {
            var branchOffices = await _branchOfficeRepository.GetAllAsync();
            return branchOffices.Select(p => new BranchOfficeResponseDTO { Id = p.Id, Name = p.Name, Address = p.Address });
        }
        public async Task<BranchOfficeResponseDTO> GetByIdAsync(int id)
        {
            var branchOffice = await _branchOfficeRepository.GetByIdAsync(id);
            return branchOffice is null ? null : new BranchOfficeResponseDTO { Id = branchOffice.Id, Name = branchOffice.Name, Address = branchOffice.Address };

        }
        public async Task<BranchOfficeResponseDTO> CreateAsync(BranchOfficeRequestDTO dto)
        {
            var branchOffice = new Domain.Entities.BranchOffice(dto.Name, dto.Address);
            await _branchOfficeRepository.AddAsync(branchOffice);
            return new BranchOfficeResponseDTO { Id = branchOffice.Id, Name = branchOffice.Name, Address = branchOffice.Address };
        }

        public async Task<bool> UpdateAsync(int id, BranchOfficeRequestDTO dto)
        {
            var branchOffice = await _branchOfficeRepository.GetByIdAsync(id);

            if (branchOffice is null)
                return false;

            branchOffice.Name = dto.Name;
            branchOffice.Address = dto.Address;

            return await _branchOfficeRepository.UpdateAsync(branchOffice);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _branchOfficeRepository.DeleteAsync(id);
        }
    }
}
