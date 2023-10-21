using Domain.Base;

namespace Domain.Entities;

public class RelBookAuthor : CoreEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }

    public Guid AuthorId { get; set; }
    public Author Author { get; set; }

}