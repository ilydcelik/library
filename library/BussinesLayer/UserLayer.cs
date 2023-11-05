using Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Application;

public class UserLayer
{
    private readonly UserDataAccess _userDataAccess;


    public UserLayer(ApplicationDbContext dbContext)
    {
        _userDataAccess = new UserDataAccess(dbContext);
    }

    public async Task DeleteUser()
    {
        Console.Write("Silmek istediğiniz kullanıcı id: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid userId))
        {
            await _userDataAccess.DeleteUser(userId);
        }
        else
        {
            Console.WriteLine("Geçersiz kullanıcı id.");
        }
    }
}