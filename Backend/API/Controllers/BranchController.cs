using Aplication.DTOs;
using Aplication.Interfaces;
using Domain.Entities;

namespace API.Controllers
{
    public class BranchController : CatalogController<Branch, CatalogRequestDTO, CatalogResponseDTO>
    {
        public BranchController(IService<Branch, CatalogRequestDTO, CatalogResponseDTO> service) : base(service) { }
    }
}
