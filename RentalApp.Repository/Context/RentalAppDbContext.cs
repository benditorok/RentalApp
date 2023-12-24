using Microsoft.EntityFrameworkCore;
using RentalApp.Model;

namespace RentalApp.Repository.Context;

public class RentalAppDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; } = null!;

    public DbSet<Customer> Customers { get; set; } = null!;

    public DbSet<Rental> Rentals { get; set; } = null!;

    public DbSet<Maintenance> Maintenances { get; set; } = null!;

    public RentalAppDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //string conn = Environment.GetEnvironmentVariable("", EnvironmentVariableTarget.User)!;

            optionsBuilder
                .UseInMemoryDatabase("inmemory")
                .UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Navigation properties
        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Rentals);

        modelBuilder.Entity<Rental>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Rentals);

        modelBuilder.Entity<Car>()
            .HasMany(c => c.Maintenances)
            .WithOne(m => m.Car);
    }
}
