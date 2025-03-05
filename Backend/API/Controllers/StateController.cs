using Aplication.DTOs;
using Aplication.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/branches")]
    public class StateController : CatalogController<State, CatalogRequestDTO, CatalogResponseDTO>
    {
        public StateController(IService<State, CatalogRequestDTO, CatalogResponseDTO> service) : base(service) { }
    }
}
