using Domain.Base;

namespace Domain.Entities;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public bool IsUsed { get; set; }

    public List<RelBookAuthor> RelBookAuthors { get; set; }
    public List<RelBookType> RelBookType { get; set; }
    public List<RelUserBook> RelUserBooks { get; set; }

}