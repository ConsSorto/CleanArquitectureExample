

using Aplication.DTOs.User;

namespace Aplication.DTOs.Truck
{
    public class TruckResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public int ConductorId { get; set; }
        public UserResponseDTO? Conductor { get; set; } // 📌 Ahora devuelve el objeto `Conductor`
    }
}
