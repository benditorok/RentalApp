using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentalApp.Repository.Context;

public class RentalAppIdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public RentalAppIdentityDbContext(DbContextOptions<RentalAppIdentityDbContext> options) : base(options)
    {
        Database.EnsureCreated();
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

        // Seed
        // Administrator role seed
        modelBuilder.Entity<IdentityRole>()
            .HasData(new IdentityRole()
            {
                Id = "3038C8A9-E8D1-4A4E-A6A8-46A8EA38AD89",
                Name = "Manager",
                NormalizedName = "MANAGER"
            });

        // Password hasher for the manager account
        var hasher = new PasswordHasher<IdentityUser>();

        // Manager account
        var mainManager = new IdentityUser()
        {
            Id = "69CA1A13-F868-42D2-8F5F-C6650B9BE577", // primary key
            UserName = "Manager",
            NormalizedUserName = "MANAGER",
            PasswordHash = hasher.HashPassword(null!, "Passw0rd")
        };

        // Manager seed
        modelBuilder.Entity<IdentityUser>()
            .HasData(mainManager);

        // Relation between the manager user and role
        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>()
            {
                RoleId = "3038C8A9-E8D1-4A4E-A6A8-46A8EA38AD89",
                UserId = "69CA1A13-F868-42D2-8F5F-C6650B9BE577"
            });
    }
}