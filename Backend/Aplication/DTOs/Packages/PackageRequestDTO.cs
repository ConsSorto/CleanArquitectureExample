
namespace Aplication.DTOs.Packages
{
    public class PackageRequestDTO
    {
        public int TruckId { get; set; }
        public int BranchId { get; set; }
        public int StateId { get; set; }
        public string Tracking { get; set; } = string.Empty;
        public int UserCreateId { get; set; }
        public int? UserReceiveId { get; set; }
        public List<PackageDetailDTO> Details { get; set; } = new();
    }
}
