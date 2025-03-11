using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DTOs.Truck;
using Aplication.DTOs.User;

namespace Aplication.DTOs.Packages
{
    public class PackageResponseDTO: PackageRequestDTO
    {
        public int Id { get; set; }
        public TruckResponseDTO? Truck { get; set; }
        public CatalogResponseDTO? Branch { get; set; }
        public CatalogResponseDTO? State { get; set; }
        public UserResponseDTO? UserCreate { get; set; }
        public UserResponseDTO? UserReceive { get; set; }
    }
}
