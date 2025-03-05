using Aplication.DTOs;
using Aplication.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController<T, TRequestDTO, TResponseDTO> : ControllerBase
        where T: EntityCatalog
        where TRequestDTO : CatalogRequestDTO
        where TResponseDTO : CatalogResponseDTO
    {
        private readonly IService<T, TRequestDTO, TResponseDTO> _service;

        public CatalogController(IService<T, TRequestDTO, TResponseDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            return entity is null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TRequestDTO dto)
        {
            var entity = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] TRequestDTO dto)
        {
            var updated = await _service.UpdateAsync(Id, dto);
            return updated ? NoContent() : NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        { 
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        
        }
    }
}
