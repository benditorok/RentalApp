using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RentalApp.Repository.Context;

public class RentalAppIdentityContextFactory : IDesignTimeDbContextFactory<RentalAppIdentityDbContext>
{
    public RentalAppIdentityDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RentalAppIdentityDbContext>();

        string? conn = Environment.GetEnvironmentVariable("NPGSQL_RENTAL")! ?? Environment.GetEnvironmentVariable("NPGSQL_RENTAL", EnvironmentVariableTarget.User)!;

        // If no connection string is present, it will use an inmemory database
        if (conn is not null)
        {
            optionsBuilder
            .UseNpgsql(conn, x => x.MigrationsAssembly("RentalApp.Repository"))
            .UseLazyLoadingProxies();
        }
        else
        {
            optionsBuilder
            .UseInMemoryDatabase("rental")
            .UseLazyLoadingProxies();
        }

        return new RentalAppIdentityDbContext(optionsBuilder.Options);
    }
}
