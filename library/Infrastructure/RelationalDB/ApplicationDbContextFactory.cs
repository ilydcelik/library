using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RelationalDB;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        var connectionString = configuration
                    .GetConnectionString("SqlConnectionString");

        dbContextOptionsBuilder.UseSqlServer(connectionString);

        var dbContextOptions = dbContextOptionsBuilder.Options;


        return new ApplicationDbContext(dbContextOptionsBuilder.Options);
    }

    internal IDisposable CreateDbContext(object args)
    {
        throw new NotImplementedException();
    }
}