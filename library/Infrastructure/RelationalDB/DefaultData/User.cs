using Domain.Entities;

namespace Infrastructure.RelationalDB;

public partial class DefaultData
{
    public static User User = new User()
    {
        Id = Guid.Parse("3d5dd8ca-be9c-4072-be9f-934720decd25"),
        Username = "ilayda.celik'",
        FirstName = "ilayda",
        LastName = "celik",
        CreatedAt = DateTime.Now,
    };
    public static List<User> Users = new List<User>()
    {
       User,
    };
}