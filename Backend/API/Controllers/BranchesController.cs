using Aplication.DTOs;
using Aplication.Interfaces;
using Domain.Entities;

namespace API.Controllers
{
    public class BranchesController : CatalogController<Branch, CatalogRequestDTO, CatalogResponseDTO>
    {
        public BranchesController(IService<Branch, CatalogRequestDTO, CatalogResponseDTO> service) : base(service) { }
    }
}
