using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application;

public class AuthorDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public AuthorDataAccess(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task GetAllAuthors()
    {
        var authors = _dbContext.Authors.Where(b => !b.IsDeleted).ToList();

        for (int i = 0; i < authors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {authors[i].Id} {authors[i].Name}");
        }
    }

    public async Task AddAuthor()
    {
        Console.WriteLine("Yazar girin: ");
        var author = Console.ReadLine();
        var newAuthor = new Author
        {
            Name = author,
        };
        _dbContext.Authors.Add(newAuthor);
        _dbContext.SaveChanges();
        Console.WriteLine("Yazar eklendi.");
    }

    public async Task DeleteAuthor(Guid authorId)
    {
        var author = await _dbContext.Authors.FindAsync(authorId);

        if (author != null && !author.IsDeleted)
        {
            author.IsDeleted = true;
            _dbContext.SaveChanges();
            Console.WriteLine("Yazar silindi.");
        }
        else
        {
            Console.WriteLine("Yazar bulunamadı.");
        }
    }
}