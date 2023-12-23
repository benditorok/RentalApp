using Microsoft.EntityFrameworkCore;
using RentalApp.Model;

namespace RentalApp.Repository.Context;

public class RentalAppDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Rental> Rentals { get; set; }

    public DbSet<Maintenance> Maintenances { get; set; }

    public RentalAppDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string conn = Environment.GetEnvironmentVariable("MYSQL_RENTAL", EnvironmentVariableTarget.User)!;

            optionsBuilder
                .UseMySQL(conn)
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
