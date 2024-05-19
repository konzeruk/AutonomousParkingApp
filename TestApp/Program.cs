using AutonomousParkingApp.StorageCarNumbers.DB.Contexts;
using AutonomousParkingApp.StorageCarNumbers.DB.Models.Entities;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

using (var context = new StorageCarNumbersContext(config, true))
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
