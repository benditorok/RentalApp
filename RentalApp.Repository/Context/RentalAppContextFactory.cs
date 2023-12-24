using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RentalApp.Repository.Context;

public class RentalAppContextFactory : IDesignTimeDbContextFactory<RentalAppDbContext>
{
    public RentalAppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RentalAppDbContext>();

        string conn = Environment.GetEnvironmentVariable("NPGSQL_RENTAL", EnvironmentVariableTarget.User)
                ?? Environment.GetEnvironmentVariable("NPGSQL_RENTAL")!;

        optionsBuilder
            .UseNpgsql(conn, x => x.MigrationsAssembly("RentalApp.Repository"))
            .UseLazyLoadingProxies();

        return new RentalAppDbContext(optionsBuilder.Options);
    }
}
