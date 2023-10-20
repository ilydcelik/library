namespace Infrastructure.RelationalDB;
public static class CustomModelBuilder
{
    public static void Build(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        Seeder.Seed(modelBuilder);
    }
}