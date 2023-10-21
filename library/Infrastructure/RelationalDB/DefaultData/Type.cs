using Domain.Entities;

namespace Infrastructure.RelationalDB;

public partial class DefaultData
{
    public static BookType BookType = new BookType()
    {
        Id = Guid.Parse("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
        Name = "Kurgu",
        CreatedAt = DateTime.Now,
    };
    public static List<BookType> BookTypes = new List<BookType>()
    {
       BookType,
    };
}