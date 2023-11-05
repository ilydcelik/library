using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application;

public class UserDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public UserDataAccess(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task GetAllUsers()
    {
        var users = _dbContext.Users.ToList();

        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i].Id} {users[i].Username}");
        }
    }

    public async Task AddUser()
    {
        Console.WriteLine("Ad: ");
        string newFirstName = Console.ReadLine();
        Console.WriteLine("Soyad: ");
        string newLastName = Console.ReadLine();
        Console.WriteLine("Kullanıcı Adı: ");
        string newUserName = Console.ReadLine();


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

    public async Task DeleteUser(Guid userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);

        if (user != null && !user.IsDeleted)
        {
            user.IsDeleted = true;
            _dbContext.SaveChanges();
            Console.WriteLine("Kulllanıcı silindi.");
        }
        else
        {
            Console.WriteLine("Kulllanıcı bulunamadı.");
        }
    }
}