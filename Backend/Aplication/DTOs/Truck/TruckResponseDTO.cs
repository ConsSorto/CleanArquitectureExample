

using Aplication.DTOs.User;

namespace Aplication.DTOs.Truck
{
    public class TruckResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public int DriverId { get; set; }
        public UserResponseDTO? Driver { get; set; } // `Driver`
    }
}
