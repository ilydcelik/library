using Domain.Entities;

namespace Infrastructure.RelationalDB;

public partial class DefaultData
{
    public static Book Book = new Book()
    {
        Id = Guid.Parse("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
        Name = "Marti",
        CreatedAt = DateTime.Now,
    };
    public static List<Book> Books = new List<Book>()
    {
       Book,
    };
}