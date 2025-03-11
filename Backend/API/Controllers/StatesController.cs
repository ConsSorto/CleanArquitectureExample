using Aplication.DTOs;
using Aplication.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StatesController : CatalogController<State, CatalogRequestDTO, CatalogResponseDTO>
    {
        public StatesController(IService<State, CatalogRequestDTO, CatalogResponseDTO> service) : base(service) { }
    }
}
