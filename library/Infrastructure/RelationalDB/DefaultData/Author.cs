using Domain.Entities;

namespace Infrastructure.RelationalDB;

public partial class DefaultData
{
    public static Author Author = new Author()
    {
        Id = Guid.Parse("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
        Name = "Richard Bach",
        CreatedAt = DateTime.Now,
    };
    public static List<Author> Authors = new List<Author>()
    {
       Author,
    };
}