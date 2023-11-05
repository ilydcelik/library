using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application;

public class BookDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public BookDataAccess(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
                    if (!relBookAuthor.Author.IsDeleted)
                    {
                        System.Console.Write(relBookAuthor.Author.Name + ", ");
                    }
                }
                System.Console.WriteLine();
            }

            if (book.RelBookType.Any())
            {
                System.Console.Write("Türler: ");
                foreach (var relBookType in book.RelBookType)
                {
                    if (!relBookType.Type.IsDeleted)
                    {
                        System.Console.Write(relBookType.Type.Name + ", ");
                    }
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine("Kullanım durumu: " + book.IsUsed);

            System.Console.WriteLine();
        }
    }

    public async Task AddBook()
    {
        Console.Write("Kitap adını girin: ");
        string bookName = Console.ReadLine();

        var newBook = new Book
        {
            Name = bookName,
            IsUsed = false,
            RelBookAuthors = new List<RelBookAuthor>(),
            RelBookType = new List<RelBookType>()
        };

        bool addingAuthors = true;

        while (addingAuthors)
        {
            // Yazarları listele
            var authors = _dbContext.Authors.ToList();

            Console.WriteLine("Yazarları Seçin:");
            for (int i = 0; i < authors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {authors[i].Name}");
            }
            Console.WriteLine("Var olan bir yazar seçmek için yazarın numarasını girin. Yeni bir yazar eklemek için 'Y' girin veya çıkmak için 'E' girin.");
            string authorChoice = Console.ReadLine();
            Author selectedAuthor = null;

            if (authorChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Yeni yazarın adını girin: ");
                string newAuthorName = Console.ReadLine();
                selectedAuthor = new Author { Name = newAuthorName };
                _dbContext.Authors.Add(selectedAuthor);
                _dbContext.SaveChanges();
            }
            else if (authorChoice.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                addingAuthors = false;
            }
            else if (int.TryParse(authorChoice, out int authorIndex) && authorIndex > 0 && authorIndex <= authors.Count)
            {
                selectedAuthor = authors[authorIndex - 1];
            }

            if (selectedAuthor != null)
            {
                newBook.RelBookAuthors.Add(new RelBookAuthor { Author = selectedAuthor });
            }
        }

        // Kitap türlerini listele
        var types = _dbContext.BookTypes.ToList();

        Console.WriteLine("Kitap Türlerini Seçin:");
        for (int i = 0; i < types.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {types[i].Name}");
        }
        Console.WriteLine("Var olan bir tür seçmek için türün numarasını girin. Yeni bir tür eklemek için 'Y' girin.");
        string typeChoice = Console.ReadLine();
        BookType selectedType = null;

        if (typeChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            Console.Write("Yeni kitap türünün adını girin: ");
            string newTypeName = Console.ReadLine();
            selectedType = new BookType { Name = newTypeName };
            _dbContext.BookTypes.Add(selectedType);
            _dbContext.SaveChanges();
        }
        else if (int.TryParse(typeChoice, out int typeIndex) && typeIndex > 0 && typeIndex <= types.Count)
        {
            selectedType = types[typeIndex - 1];
        }

        if (selectedType != null)
        {
            newBook.RelBookType.Add(new RelBookType { Type = selectedType });
        }

        _dbContext.Books.Add(newBook);
        _dbContext.SaveChanges();

        Console.WriteLine("Kitap eklendi.");
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

    public async Task ReturnBook(Guid userId, Guid bookId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        var book = await _dbContext.Books.FindAsync(bookId);

        if (user == null || book == null)
        {
            Console.WriteLine("Geçersiz kullanıcı veya kitap.");
            return;
        }

        var relUserBook = await _dbContext.RelUserBooks
            .Where(r => r.UserId == userId && r.BookId == bookId && r.ReturnDate == null)
            .FirstOrDefaultAsync();

        if (relUserBook != null)
        {
            relUserBook.ReturnDate = DateTime.Now;
            book.IsUsed = false;
            // relUserBook.BookId = null; 
            // relUserBook.UserId = null; 

            await _dbContext.SaveChangesAsync();
            Console.WriteLine("Kitap iade edildi.");
        }
        else
        {
            Console.WriteLine("Kullanıcı bu kitabı ödünç almamış.");
        }
    }

    public async Task AddAdditionalAuthorsToBook(Guid bookId)
    {
        var book = await _dbContext.Books
            .Include(b => b.RelBookAuthors)
            .FirstOrDefaultAsync(b => b.Id == bookId);

        if (book == null)
        {
            Console.WriteLine("Kitap bulunamadı.");
            return;
        }

        bool addingAuthors = true;

        while (addingAuthors)
        {
            // Yazarları listele
            var authors = _dbContext.Authors.ToList();

            Console.WriteLine("Yazarları Seçin:");
            for (int i = 0; i < authors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {authors[i].Name}");
            }
            Console.WriteLine("Var olan bir yazar seçmek için yazarın numarasını girin. Yeni bir yazar eklemek için 'Y' girin veya çıkmak için 'E' girin.");
            string authorChoice = Console.ReadLine();
            Author selectedAuthor = null;

            if (authorChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Yeni yazarın adını girin: ");
                string newAuthorName = Console.ReadLine();
                selectedAuthor = new Author { Name = newAuthorName };
                _dbContext.Authors.Add(selectedAuthor);
                _dbContext.SaveChanges();
            }
            else if (authorChoice.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                addingAuthors = false;
            }
            else if (int.TryParse(authorChoice, out int authorIndex) && authorIndex > 0 && authorIndex <= authors.Count)
            {
                selectedAuthor = authors[authorIndex - 1];
            }

            if (selectedAuthor != null)
            {
                book.RelBookAuthors.Add(new RelBookAuthor { Author = selectedAuthor });
            }
        }

        _dbContext.SaveChanges();
        Console.WriteLine("Ek yazarlar kitaba eklendi.");
    }

    public async Task AddAdditionalTypesToBook(Guid bookId)
    {
        var book = await _dbContext.Books
            .Include(b => b.RelBookType)
            .FirstOrDefaultAsync(b => b.Id == bookId);

        if (book == null)
        {
            Console.WriteLine("Kitap bulunamadı.");
            return;
        }

        bool addingTypes = true;

        while (addingTypes)
        {
            // Türleri listele
            var types = _dbContext.BookTypes.ToList();

            Console.WriteLine("Türleri Seçin:");
            for (int i = 0; i < types.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {types[i].Name}");
            }
            Console.WriteLine("Var olan bir tür seçmek için türün numarasını girin. Yeni bir tür eklemek için 'Y' girin veya çıkmak için 'E' girin.");
            string typeChoice = Console.ReadLine();
            BookType selectedType = null;

            if (typeChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Yeni türün adını girin: ");
                string newTypeName = Console.ReadLine();
                selectedType = new BookType { Name = newTypeName };
                _dbContext.BookTypes.Add(selectedType);
                _dbContext.SaveChanges();
            }
            else if (typeChoice.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                addingTypes = false;
            }
            else if (int.TryParse(typeChoice, out int typeIndex) && typeIndex > 0 && typeIndex <= types.Count)
            {
                selectedType = types[typeIndex - 1];
            }

            if (selectedType != null)
            {
                book.RelBookType.Add(new RelBookType { Type = selectedType });
            }
        }

        _dbContext.SaveChanges();
        Console.WriteLine("Ek türler kitaba eklendi.");
    }

}