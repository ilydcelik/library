using System.Xml.Serialization;
using Domain.Entities;
using Infrastructure.RelationalDB;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Application;


namespace Infrastructure.Services;

public class AppService
{
    private readonly BookLayer _bookLayer;
    private readonly AuthorLayer _authorLayer;
    private readonly UserLayer _userLayer;
    private readonly BookTypeLayer _bookTypeLayer;

    private readonly BookTypeDataAccess _bookTypeDataAccess;
    private readonly UserDataAccess _userDataAccess;
    private readonly AuthorDataAccess _authorDataAccess;
    private readonly BookDataAccess _bookDataAccess;

    public AppService(ApplicationDbContext dbContext)
    {
        _bookLayer = new BookLayer(dbContext);
        _authorLayer = new AuthorLayer(dbContext);
        _userLayer = new UserLayer(dbContext);
        _bookTypeLayer = new BookTypeLayer(dbContext);
        _bookTypeDataAccess = new BookTypeDataAccess(dbContext);
        _userDataAccess = new UserDataAccess(dbContext);
        _authorDataAccess = new AuthorDataAccess(dbContext);
        _bookDataAccess = new BookDataAccess(dbContext);
    }

    public async Task Promt()
    {
        while (true)
        {
            System.Console.WriteLine("------------------------------------------------------------------------");
            System.Console.WriteLine("\n\nYapilabilecek islemler:");
            System.Console.WriteLine("0) Uygulamadan cikmak icin");
            System.Console.WriteLine("1) Tum Kitaplari listele");
            System.Console.WriteLine("2) Tum Yazarları listele");
            System.Console.WriteLine("3) Tum Kitap Türlerini listele");
            System.Console.WriteLine("4) Tum Kullanıcıları listele");
            System.Console.WriteLine("5) Kitap ekle");
            System.Console.WriteLine("6) Kitap sil");
            System.Console.WriteLine("7) Kitap al");
            System.Console.WriteLine("8) Kitap birak");
            System.Console.WriteLine("9) Yazar ekle");
            System.Console.WriteLine("10) Kitap türü ekle");
            System.Console.WriteLine("11) Yeni kullanıcı ekle");
            System.Console.WriteLine("12) Kullanıcı sil");
            System.Console.WriteLine("13) Yazar sil");
            System.Console.WriteLine("14) Kitap türü sil");
            System.Console.WriteLine("15) Kitaba ek yazarlar ekle");
            System.Console.WriteLine("16) Kitaba ek türler ekle");
            System.Console.Write("Yapmak istediginiz islemin numarasini giriniz: ");
            var selection = Convert.ToInt32(System.Console.ReadLine());
            switch (selection)
            {
                case 0:
                    return;
                case 1:
                    {
                        await _bookDataAccess.GetAllBooks();
                        break;
                    }
                case 2:
                    {
                        await _authorDataAccess.GetAllAuthors();
                        break;
                    }
                case 3:
                    {
                        await _bookTypeDataAccess.GetAllBookTypes();
                        break;
                    }
                case 4:
                    {
                        await _userDataAccess.GetAllUsers();
                        break;
                    }
                case 5:
                    {
                        await _bookDataAccess.AddBook();
                        break;
                    }

                case 6:
                    {
                        await _bookLayer.DeleteBook();
                        break;
                    }
                case 7:
                    {
                        await _bookLayer.BorrowBook();
                        break;
                    }
                case 8:
                    {
                        await _bookLayer.ReturnBook();
                        break;
                    }
                case 9:
                    {
                        await _authorDataAccess.AddAuthor();
                        break;
                    }
                case 10:
                    {
                        await _bookTypeDataAccess.AddBookType();
                        break;
                    }
                case 11:
                    {
                        await _userDataAccess.AddUser();
                        break;
                    }
                case 12:
                    {
                        await _userLayer.DeleteUser();
                        break;
                    }
                case 13:
                    {
                        await _authorLayer.DeleteAuthor();
                        break;
                    }
                case 14:
                    {
                        await _bookTypeLayer.DeleteBookType();
                        break;
                    }
                case 15:
                    {
                        await _bookLayer.AddAdditionalAuthorsToBook();
                        break;
                    }
                case 16:
                    {
                        await _bookLayer.AddAdditionalTypesToBook();
                        break;
                    }
                default:
                    System.Console.WriteLine("Seciminiz yanlis. Kontrol ediniz.");
                    break;
            }
        }
    }
}
