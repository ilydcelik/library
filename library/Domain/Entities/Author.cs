using Domain.Base;

namespace Domain.Entities;

public class Author : BaseEntity
{
    public string Name { get; set; }
    public List<RelBookAuthor> RelBookAuthors { get; set; }

}