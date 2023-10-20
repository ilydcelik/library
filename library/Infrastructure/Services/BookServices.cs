using System.Xml.Serialization;
using Domain.Entities;
using Infrastructure.RelationalDB;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AppService
{
    public ApplicationDbContext _dbContext { get; set; }

    public AppService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Promt()
    {
        while (true)
        {
            System.Console.WriteLine("\n\nYapilabilecek islemler:");
            System.Console.WriteLine("0) Uygulamadan cikmak icin");
            System.Console.WriteLine("1) Tum Kitaplari listele");
            System.Console.WriteLine("2) ...");
            System.Console.Write("Yapmak istediginiz islemin numarasini giriniz: ");
            var selection = Convert.ToInt32(System.Console.ReadLine());
            switch (selection)
            {
                case 0:
                    return;

                case 1:
                    await GetAllBooks();
                    break;

                default:
                    System.Console.WriteLine("Seciminiz yanlis. Kontrol ediniz...");
                    break;
            }
        }
    }

    public async Task GetAllBooks()
    {
        var books = await _dbContext.Books.ToListAsync();

        foreach (var book in books)
        {
            System.Console.WriteLine(book.Id);
            System.Console.WriteLine(book.Name);
        }
    }
}