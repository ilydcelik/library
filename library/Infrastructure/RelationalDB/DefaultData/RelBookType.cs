using Domain.Entities;

namespace Infrastructure.RelationalDB;

public partial class DefaultData
{
    public static RelBookType RelBookType = new RelBookType()
    {
        Id = Guid.Parse("8abac909-6cee-4799-b467-680a814604d3"),
        BookId = Guid.Parse("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
        TypeId = Guid.Parse("cb03753a-aabb-430d-8575-1cf524e2e2ea"),
    };
    public static List<RelBookType> RelBookTypes = new List<RelBookType>()
    {
       RelBookType,
    };
}