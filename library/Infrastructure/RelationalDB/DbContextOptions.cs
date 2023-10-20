using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RelationalDB;
public class CustomDbContextOptions
{
    public readonly DbContextOptions<ApplicationDbContext> DbContextOptions;
    public CustomDbContextOptions(string connectionString)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        dbContextOptionsBuilder.UseSqlServer(connectionString);

        this.DbContextOptions = dbContextOptionsBuilder.Options;
    }
}