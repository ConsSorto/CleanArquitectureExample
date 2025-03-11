using Domain.AggregateRoots.Packages;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Infrastructure.Persistence
{
    public class BackendDBContext : DbContext
    {
        public BackendDBContext(DbContextOptions<BackendDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageDetail> PackageDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Truck>()
               .HasOne(t => t.Driver)   // Un Truck tiene un User
               .WithMany()                 // Un Conductor puede tener muchos Trucks (si aplica)
               .HasForeignKey(t => t.DriverId) // La FK es ConductorId
               .OnDelete(DeleteBehavior.Restrict);

            //Package -> Truck
            modelBuilder.Entity<Package>()
                .HasOne(p => p.Truck)
                .WithMany()
                .HasForeignKey(p => p.TruckId)
                .OnDelete(DeleteBehavior.Restrict);

            //Package -> Branch
            modelBuilder.Entity<Package>()
                .HasOne(p => p.Branch)
                .WithMany()
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            //Package -> State
            modelBuilder.Entity<Package>()
                .HasOne(p => p.State)
                .WithMany()
                .HasForeignKey(p => p.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            //Package -> UserCreate (Usuario que creo el paquete)
            modelBuilder.Entity<Package>()
                .HasOne(p => p.UserCreate)
                .WithMany()
                .HasForeignKey(p => p.UserCreateId)
                .OnDelete(DeleteBehavior.Restrict);

            //Package -> UserReceive (Usuario que recibe el paquete)
            modelBuilder.Entity<Package>()
                .HasOne(p => p.UserReceive)
                .WithMany()
                .HasForeignKey(p => p.UserReceiveId)
                .OnDelete(DeleteBehavior.Restrict);

            //PackageDetail -> Package
            modelBuilder.Entity<PackageDetail>()
                .HasOne(d => d.Package)
                .WithMany(p => p.Details) // Un Package tiene muchos PackageDetails
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.Cascade); // Si se borra un Package, se borran sus PackageDetails

            //PackageDetail -> Product
            modelBuilder.Entity<PackageDetail>()
                .HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
