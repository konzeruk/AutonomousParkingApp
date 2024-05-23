using AutonomousParkingApp.Authentication.DB.Contexts;
using AutonomousParkingApp.Authentication.DB.Models;
using AutonomousParkingApp.StorageCarNumbers.DB.Contexts;
using AutonomousParkingApp.StorageCarNumbers.DB.Models.Entities;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

/*using (var context = new StorageCarNumbersContext(config, true))
{
    var parking = new ParkingEntity
    {
        NumFreeSpaces = 15,
        Address = "ffffff",
        Price = 10
    };

    context.Parkings.Add(parking);
    context.SaveChanges();
}

var g1 = Guid.NewGuid();
var g2 = Guid.NewGuid();

Console.WriteLine(g1);
Console.WriteLine(g2);
*/
using (var context = new AuthContext(config, true))
{
    var parking = new UserEntity
    {
        Name = "admin",
        Login = "admin",
        Password = "admin",
        CardNumber = "111111",
        Phone = "111111",
        CarNumber = "11111"
    };

    context.Users.Add(parking);
    context.SaveChanges();
}


