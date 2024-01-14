using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RentalApp.Repository.Context;

public class RentalAppContextFactory : IDesignTimeDbContextFactory<RentalAppDbContext>
{
    public RentalAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RentalAppDbContext>();

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

        return new RentalAppDbContext(optionsBuilder.Options);
    }
}
