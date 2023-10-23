using Domain.Entities;

namespace Infrastructure.RelationalDB;

public static class Seeder
{
    public static void Seed(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(DefaultData.Books);
        modelBuilder.Entity<Author>().HasData(DefaultData.Authors);
        modelBuilder.Entity<BookType>().HasData(DefaultData.BookTypes);
        modelBuilder.Entity<User>().HasData(DefaultData.Users);
        modelBuilder.Entity<RelBookAuthor>().HasData(DefaultData.RelBookAuthors);
        modelBuilder.Entity<RelBookType>().HasData(DefaultData.RelBookTypes);
        modelBuilder.Entity<RelUserBook>().HasData(DefaultData.RelUserBooks);
    }
}