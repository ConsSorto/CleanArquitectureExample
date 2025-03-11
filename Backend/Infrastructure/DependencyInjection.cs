
using Aplication.DTOs;
using Aplication.Interfaces;
using Aplication.Interfaces.Packages;
using Aplication.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Packages;
using Microsoft.Extensions.DependencyInjection;
using Aplication.Services.Packages;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<,,>), typeof(Service<,,>));

            services.AddScoped<IService<Branch, CatalogRequestDTO, CatalogResponseDTO>, Service<Branch, CatalogRequestDTO, CatalogResponseDTO>>();
            services.AddScoped<IService<State, CatalogRequestDTO, CatalogResponseDTO>, Service<State, CatalogRequestDTO, CatalogResponseDTO>>();

            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPackageService, PackageService>();

            return services;
        }
    }
}
