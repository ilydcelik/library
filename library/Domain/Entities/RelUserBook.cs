using Domain.Base;

namespace Domain.Entities;

public class RelUserBook : CoreEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }

    public Guid Userd { get; set; }
    public User User { get; set; }
}