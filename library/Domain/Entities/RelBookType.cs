using Domain.Base;

namespace Domain.Entities;

public class RelBookType : CoreEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }

    public Guid TypeId { get; set; }
    public BookType Type { get; set; }

}
