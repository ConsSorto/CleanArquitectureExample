using Aplication.DTOs;
using Aplication.Interfaces;
using Domain.Common;

namespace Aplication.Services
{
    public class Service<T, TRequestDTO, TResponseDTO> : IService<T, TRequestDTO, TResponseDTO>
        where T: EntityCatalog, new()
        where TRequestDTO : CatalogRequestDTO
        where TResponseDTO : CatalogResponseDTO, new()
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TResponseDTO>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new TResponseDTO { Id = e.Id, Name = e.Name });
        }

        public async Task<TResponseDTO> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : new TResponseDTO { Id = entity.Id, Name = entity.Name };
        }

        public async Task<TResponseDTO> CreateAsync(TRequestDTO dto)
        {
            var entity = new T { Name = dto.Name };
            await _repository.AddAsync(entity);
            return new TResponseDTO { Id = entity.Id, Name = entity.Name };
        }

        public async Task<bool> UpdateAsync(int id, TRequestDTO dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;
            entity.Name = dto.Name;
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }




    }
}
