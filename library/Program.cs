using Domain.Entities;
using Infrastructure.RelationalDB;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;


var dbContext = new ApplicationDbContextFactory().CreateDbContext(new string[] { });

System.Console.WriteLine("Done.");
var bookService = new AppService(dbContext);

await bookService.Promt();
