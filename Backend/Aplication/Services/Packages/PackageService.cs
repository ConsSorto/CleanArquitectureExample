using Aplication.DTOs.Packages;
using Aplication.DTOs.Truck;
using Aplication.DTOs;
using Aplication.Interfaces.Packages;
using Domain.AggregateRoots.Packages;
using Aplication.DTOs.User;

namespace Aplication.Services.Packages
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<IEnumerable<PackageResponseDTO>> GetAllAsync()
        {
            var packages = await _packageRepository.GetAllAsync();
            return packages.Select(p => new PackageResponseDTO
            {
                Id = p.Id,
                TruckId = p.TruckId,
                Truck = p.Truck != null ? new TruckResponseDTO
                {
                    Id = p.Truck.Id,
                    Name = p.Truck.Name,
                    Plate = p.Truck.Plate,
                    DriverId = p.Truck.DriverId,
                    Driver = p.Truck.Driver != null ? new UserResponseDTO { Id = p.Truck.Driver.Id, Name = p.Truck.Driver.Name } : null
                } : null,
                BranchId = p.BranchId,
                Branch = p.Branch != null ? new CatalogResponseDTO { Id = p.Branch.Id, Name = p.Branch.Name } : null,
                StateId = p.StateId,
                State = p.State != null ? new CatalogResponseDTO { Id = p.State.Id, Name = p.State.Name } : null,
                Tracking = p.Tracking,
                UserCreateId = p.UserCreateId,
                UserCreate = p.UserCreate != null ? new UserResponseDTO { Id = p.UserCreate.Id, Name = p.UserCreate.Name } : null,
                UserReceiveId = p.UserReceiveId,
                UserReceive = p.UserReceive != null ? new UserResponseDTO { Id = p.UserReceive.Id, Name = p.UserReceive.Name } : null,
                Details = p.Details.Select(d => new PackageDetailReponseDTO
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    Product = d.Product != null ? new ProductResponseDTO { Id = d.Product.Id, Name = d.Product.Name } : null
                }).ToList()
            });
        }


        public async Task<PackageResponseDTO?> GetByIdAsync(int id)
        {
            var p = await _packageRepository.GetByIdAsync(id);
            return p is null ? null : new PackageResponseDTO
            {
                Id = p.Id,
                TruckId = p.TruckId,
                BranchId = p.BranchId,
                StateId = p.StateId,
                Tracking = p.Tracking,
                UserCreateId = p.UserCreateId,
                UserReceiveId = p.UserReceiveId,
                Truck = p.Truck != null ? new TruckResponseDTO
                {
                    Id = p.Truck.Id,
                    Name = p.Truck.Name,
                    Plate = p.Truck.Plate,
                    DriverId = p.Truck.DriverId,
                    Driver = p.Truck.Driver != null ? new UserResponseDTO { Id = p.Truck.Driver.Id, Name = p.Truck.Driver.Name } : null
                } : null,
                Branch = p.Branch != null ? new CatalogResponseDTO { Id = p.Branch.Id, Name = p.Branch.Name } : null,
                State = p.State != null ? new CatalogResponseDTO { Id = p.State.Id, Name = p.State.Name } : null,
                UserCreate = p.UserCreate != null ? new UserResponseDTO { Id = p.UserCreate.Id, Name = p.UserCreate.Name } : null,
                UserReceive = p.UserReceive != null ? new UserResponseDTO { Id = p.UserReceive.Id, Name = p.UserReceive.Name } : null,
                Details = p.Details.Select(d => new PackageDetailReponseDTO
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    Product = d.Product != null ? new ProductResponseDTO { Id = d.Product.Id, Name = d.Product.Name } : null
                }).ToList()
            };
        }


        public async Task<PackageResponseDTO> CreateAsync(PackageRequestDTO dto)
        {
            var package = new Package
            {
                TruckId = dto.TruckId,
                BranchId = dto.BranchId,
                StateId = dto.StateId,
                Tracking = dto.Tracking,
                UserCreateId = dto.UserCreateId,
                UserReceiveId = dto.UserReceiveId,
                Details = dto.Details.Select(d => new PackageDetail
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity
                }).ToList()
            };

            await _packageRepository.AddAsync(package);

            return new PackageResponseDTO
            {
                Id = package.Id,
                TruckId = package.TruckId,
                BranchId = package.BranchId,
                StateId = package.StateId,
                Tracking = package.Tracking,
                UserCreateId = package.UserCreateId,
                UserReceiveId = package.UserReceiveId,
                Details = package.Details.Select(d => new PackageDetailReponseDTO
                {
                    ProductId = d.ProductId,
                    Quantity = d.Quantity
                }).ToList()
            };
        }


        public async Task<bool> UpdateAsync(int id, PackageRequestDTO dto)
        {
            var package = await _packageRepository.GetByIdAsync(id);
            if (package is null) return false;

            package.TruckId = dto.TruckId;
            package.BranchId = dto.BranchId;
            package.StateId = dto.StateId;
            package.Tracking = dto.Tracking;
            package.UserReceiveId = dto.UserReceiveId;

            // Actualizar detalles
            package.Details.Clear();
            package.Details.AddRange(dto.Details.Select(d => new PackageDetail
            {
                ProductId = d.ProductId,
                Quantity = d.Quantity
            }));

            return await _packageRepository.UpdateAsync(package);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            return await _packageRepository.DeleteAsync(id);
        }
    }
}
