using Domain.Base;

namespace Domain.Entities;

public class RelUserAuthor : BaseEntity
{
    public string Name { get; set; }
    public bool IsUsed { get; set; }

    // public List<RelRelUserAuthorAuthor> RelRelUserAuthorAuthors { get; set; }

}

// kitap ekle methodu yazalım burada bağlı olduğu iki tane tablo var yazar ve tür tablosu