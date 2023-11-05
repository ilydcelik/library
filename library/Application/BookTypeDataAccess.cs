using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application;

public class BookTypeDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public BookTypeDataAccess(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task GetAllBookTypes()
    {
        var bookTypes = _dbContext.BookTypes.Where(b => !b.IsDeleted).ToList();

        for (int i = 0; i < bookTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {bookTypes[i].Id} {bookTypes[i].Name}");
        }
    }

    public async Task AddBookType()
    {
        Console.WriteLine("Kitap türünü girin: ");
        var bookType = Console.ReadLine();

        var newBookType = new BookType
        {
            Name = bookType,
        };
        _dbContext.BookTypes.Add(newBookType);
        _dbContext.SaveChanges();
        Console.WriteLine("Kitap eklendi.");
    }

    public async Task DeleteBookType(Guid bookTypeId)
    {
        var bookType = await _dbContext.BookTypes.FindAsync(bookTypeId);

        if (bookType != null && !bookType.IsDeleted)
        {
            bookType.IsDeleted = true;
            _dbContext.SaveChanges();
            Console.WriteLine("Kitap türü silindi.");
        }
        else
        {
            Console.WriteLine("Kitap türü bulunamadı.");
        }
    }
}