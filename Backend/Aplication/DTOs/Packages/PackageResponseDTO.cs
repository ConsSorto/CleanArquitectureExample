using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DTOs.Truck;
using Aplication.DTOs.User;

namespace Aplication.DTOs.Packages
{
    public class PackageResponseDTO
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public int BranchId { get; set; }
        public int StateId { get; set; }
        public string Tracking { get; set; } = string.Empty;
        public int UserCreateId { get; set; }
        public int? UserReceiveId { get; set; }
        public List<PackageDetailReponseDTO> Details { get; set; } = new();
        public TruckResponseDTO? Truck { get; set; }
        public CatalogResponseDTO? Branch { get; set; }
        public CatalogResponseDTO? State { get; set; }
        public UserResponseDTO? UserCreate { get; set; }
        public UserResponseDTO? UserReceive { get; set; }
    }
}
