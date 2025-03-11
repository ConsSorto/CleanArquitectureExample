using Domain.Common;
using Domain.Entities;

namespace Domain.AggregateRoots.Packages
{
    public class PackageDetail: Entity
    {
        public int PackageId { get; set; }
        public Package? Package { get; set; } // FK con Package

        public int ProductId { get; set; }
        public Product? Product { get; set; } // FK con Product

        public int Quantity { get; set; }
    }
}
