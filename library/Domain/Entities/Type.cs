using Domain.Base;

namespace Domain.Entities;

public class BookType : BaseEntity
{
    public string Name { get; set; }
    public List<RelBookType> RelBookType { get; set; }


}