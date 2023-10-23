using Domain.Entities;

namespace Infrastructure.RelationalDB;

public partial class DefaultData
{
    public static RelUserBook RelUserBook = new RelUserBook()
    {
        Id = Guid.Parse("b37616fe-bf73-49f6-b703-efb34409d3e7"),
        BookId = Guid.Parse("1a300bd1-ef14-48a7-b074-dc0e7db5aa17"),
        UserId = Guid.Parse("3d5dd8ca-be9c-4072-be9f-934720decd25"),
    };
    public static List<RelUserBook> RelUserBooks = new List<RelUserBook>()
    {
       RelUserBook,
    };
}