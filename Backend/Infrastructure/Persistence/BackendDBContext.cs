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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Truck>()
               .HasOne(t => t.Driver)   // Un Truck tiene un User
               .WithMany()                 // Un Conductor puede tener muchos Trucks (si aplica)
               .HasForeignKey(t => t.DriverId) // La FK es ConductorId
               .OnDelete(DeleteBehavior.Restrict); 
        }

    }
}
