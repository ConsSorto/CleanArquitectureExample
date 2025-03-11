

namespace Aplication.DTOs.Packages
{
    public class PackageDetailDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductResponseDTO? Product { get; set; }
    }
}
