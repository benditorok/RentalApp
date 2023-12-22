using Microsoft.EntityFrameworkCore;
using RentalApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalApp.Repository.Context;

public class RentalAppDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Rental> Rentals { get; set; }

    public DbSet<Maintenance> Maintenances { get; set;}

    public RentalAppDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
