using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application;

public class BookTypeLayer
{
    private readonly BookTypeDataAccess _bookTypeDataAccess;


    public BookTypeLayer(ApplicationDbContext dbContext)
    {
        _bookTypeDataAccess = new BookTypeDataAccess(dbContext);
    }

    public async Task DeleteBookType()
    {
        Console.Write("Silmek istediğiniz kitap türü id: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid bookTypeId))
        {
            await _bookTypeDataAccess.DeleteBookType(bookTypeId);
        }
        else
        {
            Console.WriteLine("Geçersiz kitap türü id.");
        }
    }
}