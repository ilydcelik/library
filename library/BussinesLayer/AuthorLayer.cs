using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application;

public class AuthorLayer
{
    private readonly AuthorDataAccess _authorDataAccess;


    public AuthorLayer(ApplicationDbContext dbContext)
    {
        _authorDataAccess = new AuthorDataAccess(dbContext);
    }

    public async Task DeleteAuthor()
    {
        Console.Write("Silmek istediğiniz yazar id: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid authorId))
        {
            await _authorDataAccess.DeleteAuthor(authorId);
        }
        else
        {
            Console.WriteLine("Geçersiz yazar id.");
        }
    }
}