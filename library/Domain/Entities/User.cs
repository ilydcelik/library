using Domain.Base;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Adres { get; set; }

    public List<RelUserBook> RelUserBooks { get; set; }

}