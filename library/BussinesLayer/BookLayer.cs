using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application;

public class BookLayer
{
    private readonly BookDataAccess _bookDataAccess;


    public BookLayer(ApplicationDbContext dbContext)
    {
        _bookDataAccess = new BookDataAccess(dbContext);
    }

    public async Task BorrowBook()
    {
        Console.Write("Kullanıcı ID: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid selectedUser))
        {
            Console.Write("Kitap ID: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid idBook))
            {
                await _bookDataAccess.BorrowBook(selectedUser, idBook);
            }
            else
            {
                Console.WriteLine("Geçersiz kitap ID.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz kullanıcı ID.");
        }
    }

    public async Task ReturnBook()
    {
        Console.Write("Kullanıcı ID: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid userSelected))
        {
            Console.Write("Kitap ID: ");
            if (Guid.TryParse(Console.ReadLine(), out Guid idBook))
            {
                await _bookDataAccess.ReturnBook(userSelected, idBook);
            }
            else
            {
                Console.WriteLine("Geçersiz kitap ID.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz kullanıcı ID.");
        }
    }

    public async Task DeleteBook()
    {
        Console.Write("Silmek istediğiniz kitap id: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid bookId))
        {
            await _bookDataAccess.DeleteBook(bookId);
        }
        else
        {
            Console.WriteLine("Geçersiz kitap id.");
        }
    }

    public async Task AddAdditionalAuthorsToBook()
    {
        Console.Write("Kıtap ID: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid idBook))
        {
            await _bookDataAccess.AddAdditionalAuthorsToBook(idBook);
        }
        else
        {
            Console.WriteLine("Geçersiz kitap ID.");
        }

    }

    public async Task AddAdditionalTypesToBook()
    {
        Console.Write("Kıtap ID: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid idType))
        {
            await _bookDataAccess.AddAdditionalTypesToBook(idType);
        }
        else
        {
            Console.WriteLine("Geçersiz kitap ID.");
        }

    }
}