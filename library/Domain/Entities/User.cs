using Domain.Base;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<RelUserBook> RelUserBooks { get; set; }

}