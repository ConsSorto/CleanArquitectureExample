

namespace Aplication.DTOs.Packages
{
    public class PackageDetailReponseDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public ProductResponseDTO? Product { get; set; }
    }
}
