using Aplication.DTOs.Packages;
using Aplication.Interfaces.Packages;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/packages")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var packages = await _packageService.GetAllAsync();
            return Ok(packages);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var package = await _packageService.GetByIdAsync(id);
            return package is null ? NotFound($"El paquete con ID {id} no existe.") : Ok(package);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PackageRequestDTO dto)
        {
            if (dto is null)
                return BadRequest("Los datos del paquete son requeridos.");

            var createdPackage = await _packageService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdPackage.Id }, createdPackage);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PackageRequestDTO dto)
        {
            if (dto is null)
                return BadRequest("Los datos del paquete son requeridos.");

            var updated = await _packageService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound($"El paquete con ID {id} no existe.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _packageService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound($"El paquete con ID {id} no existe.");
        }
    }
}