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
            System.Console.WriteLine("2) Kitap ekle");
            System.Console.WriteLine("3) Kitap sil");
            System.Console.WriteLine("4) Kitap al");
            System.Console.WriteLine("5) Kitap birak");
            System.Console.WriteLine("6) Yazar ekle");
            System.Console.WriteLine("7) Kitap türü ekle");
            System.Console.WriteLine("8) Yeni kullanıcı ekle");
            System.Console.WriteLine("9) Tum Kullanıcıları listele");
            System.Console.Write("Yapmak istediginiz islemin numarasini giriniz: ");
            var selection = Convert.ToInt32(System.Console.ReadLine());
            switch (selection)
            {
                case 0:
                    return;

                case 1:
                    await GetAllBooks();
                    break;
                case 2:
                    await AddBook();
                    break;

                case 3:
                    Console.Write("Silmek istediğiniz kitap id: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid bookId))
                    {
                        await DeleteBook(bookId);
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz kitap id.");
                    }
                    break;
                case 4:
                    Console.Write("Kullanıcı ID: ");
                    if (Guid.TryParse(Console.ReadLine(), out Guid selectedUser))
                    {
                        Console.Write("Kitap ID: ");
                        if (Guid.TryParse(Console.ReadLine(), out Guid idBook))
                        {
                            await BorrowBook(selectedUser, idBook);
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

                    break;
                case 5:
                // Console.Write("Kullanıcı ID: ");
                // if (Guid.TryParse(Console.ReadLine(), out Guid userSelected))
                // {
                //     Console.Write("Kitap ID: ");
                //     if (Guid.TryParse(Console.ReadLine(), out Guid idBook))
                //     {
                //         await ReturnBook(userSelected, idBook);
                //     }
                //     else
                //     {
                //         Console.WriteLine("Geçersiz kitap ID.");
                //     }
                // }
                // else
                // {
                //     Console.WriteLine("Geçersiz kullanıcı ID.");
                // }

                // break;
                case 6:
                    {
                        string[] args = new string[] { };
                        await AddAuthor(args);
                        break;
                    }
                case 7:
                    {
                        string[] args = new string[] { };
                        await AddBookType(args);
                        break;
                    }
                case 8:
                    {
                        string[] args = new string[] { };
                        await AddUser(args);
                        break;
                    }
                case 9:
                    {
                        await GetAllUsers();
                        break;
                    }

                default:
                    System.Console.WriteLine("Seciminiz yanlis. Kontrol ediniz.");
                    break;
            }
        }
    }

    public async Task GetAllBooks()
    {
        var books = await _dbContext.Books
            .Include(b => b.RelBookAuthors)
            .ThenInclude(rba => rba.Author)
            .Include(b => b.RelBookType)
            .ThenInclude(t => t.Type)
            .Where(b => !b.IsDeleted)
            .ToListAsync();

        foreach (var book in books)
        {
            System.Console.WriteLine("Kitap ID: " + book.Id);
            System.Console.WriteLine("Kitap Adı: " + book.Name);

            if (book.RelBookAuthors.Any())
            {
                System.Console.Write("Yazarlar: ");
                foreach (var relBookAuthor in book.RelBookAuthors)
                {
                    System.Console.Write(relBookAuthor.Author.Name + ", ");
                }
                System.Console.WriteLine();
            }

            if (book.RelBookType.Any())
            {
                System.Console.Write("Türler: ");
                foreach (var relBookType in book.RelBookType)
                {
                    System.Console.Write(relBookType.Type.Name + ", ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("Kullanım durumu: " + book.IsUsed);


            System.Console.WriteLine();
        }
    }

    public async Task GetAllUsers()
    {
        var users = _dbContext.Users.ToList();

        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i].Id} {users[i].Username}");
        }

    }

    public async Task AddBook()
    {
        Console.Write("Kitap adını girin: ");
        string bookName = Console.ReadLine();

        Console.WriteLine("Yazarları listeleyin:");
        var authors = _dbContext.Authors.ToList();

        for (int i = 0; i < authors.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {authors[i].Name}");
        }

        Console.Write("Bir yazar seçin veya yeni bir yazar eklemek için 'Y' tuşuna basın: ");
        string authorChoice = Console.ReadLine();
        Author selectedAuthor = null;

        if (authorChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Yeni yazarın adını girin: ");
            string newAuthorName = Console.ReadLine();
            selectedAuthor = new Author { Name = newAuthorName };
            _dbContext.Authors.Add(selectedAuthor);
        }
        else if (int.TryParse(authorChoice, out int authorIndex) && authorIndex > 0 && authorIndex <= authors.Count)
        {
            selectedAuthor = authors[authorIndex - 1];
        }

        Console.WriteLine("Kitap türlerini listeleyin:");
        var types = _dbContext.BookTypes.ToList();
        for (int i = 0; i < types.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {types[i].Name}");
        }

        Console.Write("Bir kitap türü seçin veya yeni bir tür eklemek için 'Y' tuşuna basın: ");
        string typeChoice = Console.ReadLine();
        BookType selectedType = null;

        if (typeChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Yeni kitap türünün adını girin: ");
            string newTypeName = Console.ReadLine();
            selectedType = new BookType { Name = newTypeName };
            _dbContext.BookTypes.Add(selectedType);
        }
        else if (int.TryParse(typeChoice, out int typeIndex) && typeIndex > 0 && typeIndex <= types.Count)
        {
            selectedType = types[typeIndex - 1];
        }

        var newBook = new Book
        {
            Name = bookName,
            IsUsed = false
        };

        if (selectedAuthor != null)
        {
            newBook.RelBookAuthors = new List<RelBookAuthor> { new RelBookAuthor { Author = selectedAuthor } };
        }

        if (selectedType != null)
        {
            newBook.RelBookType = new List<RelBookType> { new RelBookType { Type = selectedType } };
        }


        _dbContext.Books.Add(newBook);
        _dbContext.SaveChanges();

        Console.WriteLine("Kitap eklendi.");
    }
    //Not: Yazar ve tür birden fazla eklenecek şekilde güncelle.

    public async Task BorrowBook(Guid selectedUser, Guid bookId)
    {
        var user = await _dbContext.Users.FindAsync(selectedUser);
        var book = await _dbContext.Books.FindAsync(bookId);

        if (user == null || book == null)
        {
            Console.WriteLine("Geçersiz kullanıcı veya kitap.");
            return;
        }

        if (book.IsUsed)
        {
            Console.WriteLine("Kitap zaten ödünç alınmış.");
            return;
        }

        var relUserBook = new RelUserBook
        {
            UserId = selectedUser,
            User = user,
            BookId = bookId,
            Book = book,
            BorrowDate = DateTime.Now
        };

        book.IsUsed = true;

        _dbContext.RelUserBooks.Add(relUserBook);
        await _dbContext.SaveChangesAsync();

        Console.WriteLine("Kitap ödünç alındı.");
    }

    // public async Task ReturnBook(Guid userId, Guid bookId)
    // {
    //     var user = await _dbContext.Users.FindAsync(userId);
    //     var book = await _dbContext.Books.FindAsync(bookId);

    //     if (user == null || book == null)
    //     {
    //         Console.WriteLine("Geçersiz kullanıcı veya kitap.");
    //         return;
    //     }

    //     var relUserBook = await _dbContext.RelUserBooks
    //         .Where(r => r.UserId == userId && r.BookId == bookId && r.ReturnDate == null)
    //         .FirstOrDefault();

    //     if (relUserBook != null)
    //     {
    //         relUserBook.ReturnDate = DateTime.Now;
    //         book.IsUsed = false;
    //         // relUserBook.BookId = null; 
    //         // relUserBook.UserId = null; 

    //         await _dbContext.SaveChangesAsync();
    //         Console.WriteLine("Kitap iade edildi.");
    //     }
    //     else
    //     {
    //         Console.WriteLine("Kullanıcı bu kitabı ödünç almamış.");
    //     }
    // }

    public async Task AddUser(string[] args)
    {
        Console.WriteLine("Ad: ");
        string newFirstName = Console.ReadLine();
        Console.WriteLine("Soyad: ");
        string newLastName = Console.ReadLine();
        Console.WriteLine("Kullanıcı Adı: ");
        string newUserName = Console.ReadLine();

        using (var _dbContext = new ApplicationDbContextFactory().CreateDbContext(args))
        {
            var newUser = new User
            {
                // Id = Guid.NewGuid(),
                Username = newUserName,
                FirstName = newFirstName,
                LastName = newLastName,
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            Console.WriteLine("Kullanıcı eklendi.");
        }
    }

    public async Task DeleteBook(Guid bookId)
    {
        var book = await _dbContext.Books.FindAsync(bookId);

        if (book != null)
        {
            book.IsDeleted = true;
            _dbContext.SaveChanges();
            Console.WriteLine("Kitap silindi.");
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
    }

    public async Task AddAuthor(string[] args)
    {
        Console.WriteLine("Yazar girin: ");
        var author = Console.ReadLine();
        using (var _dbContext = new ApplicationDbContextFactory().CreateDbContext(args))
        {
            var newAuthor = new Author
            {
                Name = author,
            };
            _dbContext.Authors.Add(newAuthor);
            _dbContext.SaveChanges();
            Console.WriteLine("Yazar eklendi.");
        }
    }

    public async Task AddBookType(string[] args)
    {
        Console.WriteLine("Kitap türünü girin: ");
        var bookType = Console.ReadLine();
        using (var _dbContext = new ApplicationDbContextFactory().CreateDbContext(args))
        {
            var newBookType = new BookType
            {
                Name = bookType,
            };
            _dbContext.BookTypes.Add(newBookType);
            _dbContext.SaveChanges();
            Console.WriteLine("Kitap eklendi.");
        }
    }
}




// public async Task ReturnBook(Guid userId, Guid bookId)
// {
//     // Kullanıcıyı, kitabı ve ödünç alma kaydını al
//     var user = await _dbContext.Users.FindAsync(userId);
//     var book = await _dbContext.Books.FindAsync(bookId);
//     var relUserBook = await _dbContext.RelUserBooks
//         .Where(rub => rub.UserId == userId && rub.BookId == bookId && rub.ReturnDate == null)
//         .FirstOrDefault();

//     if (user != null && book != null && relUserBook != null)
//     {
//         // Kitap iade edildi, iade tarihi güncellenir.
//         relUserBook.ReturnDate = DateTime.Now;
//         await _dbContext.SaveChangesAsync();
//     }
// }


