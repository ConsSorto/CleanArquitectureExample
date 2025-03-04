using Aplication.DTOs;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/branchOffices")]
    public class BranchOfficeController : ControllerBase
    {
        private readonly IBranchOfficeService _branchOfficeService;

        public BranchOfficeController(IBranchOfficeService branchOfficeService)
        {
            _branchOfficeService = branchOfficeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _branchOfficeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var branchOffice = await _branchOfficeService.GetByIdAsync(id);
            return branchOffice is null ? NotFound() : Ok(branchOffice);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BranchOfficeRequestDTO dto)
        {
            var branchOffice = await _branchOfficeService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = branchOffice.Id }, branchOffice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BranchOfficeRequestDTO dto)
        {
            var update = await _branchOfficeService.UpdateAsync(id, dto);
            return update ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _branchOfficeService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }

    }
}
