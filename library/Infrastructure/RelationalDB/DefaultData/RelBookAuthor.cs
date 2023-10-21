using Domain.Entities;

namespace Infrastructure.RelationalDB;

public partial class DefaultData
{
    public static RelBookAuthor RelBookAuthor = new RelBookAuthor()
    {
        Id = Guid.Parse("8abac909-6cee-4799-b467-680a814604d3"),
        BookId = Guid.Parse("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
        AuthorId = Guid.Parse("a28cf5ff-4fb3-47da-a4a8-aa5751cc6ea5"),
    };
    public static List<RelBookAuthor> RelBookAuthors = new List<RelBookAuthor>()
    {
       RelBookAuthor,
    };
}