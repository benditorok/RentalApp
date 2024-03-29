﻿using Microsoft.EntityFrameworkCore;
using RentalApp.Model;
using System.Text.Json;

namespace RentalApp.Repository.Context;

public class RentalAppDbContext : DbContext
{
    public virtual DbSet<Car> Cars { get; set; } = null!;

    public virtual DbSet<Customer> Customers { get; set; } = null!;

    public virtual DbSet<Rental> Rentals { get; set; } = null!;

    public virtual DbSet<Maintenance> Maintenances { get; set; } = null!;

    public RentalAppDbContext(DbContextOptions<RentalAppDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string? conn = Environment.GetEnvironmentVariable("NPGSQL_RENTAL")
                ?? Environment.GetEnvironmentVariable("NPGSQL_RENTAL", EnvironmentVariableTarget.User);

            optionsBuilder
                .UseNpgsql(conn, x => x.MigrationsAssembly("RentalApp.Repository"))
                .UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
