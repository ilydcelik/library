using Domain.Entities;

namespace Infrastructure.RelationalDB;

public static class Seeder
{
    public static void Seed(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(DefaultData.Books);
    }
}