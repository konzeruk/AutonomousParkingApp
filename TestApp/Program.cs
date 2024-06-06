using AutonomousParkingApp.Authentication.DB.Contexts;
using AutonomousParkingApp.Authentication.DB.Models;
using AutonomousParkingApp.StorageCarNumbers.DB.Contexts;
using AutonomousParkingApp.StorageCarNumbers.DB.Models.Entities;
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

using (var context = new StorageCarNumbersContext(config, true))
{
    var parking1 = new ParkingEntity
    {
        NumFreeSpaces = 15,
        Address = "Пенза, ул. Революционная, 21",
        Price = 1000,
        XCoord = 53.191376,
        YCoord = 45.000279
    };

    var parking2 = new ParkingEntity
    {
        NumFreeSpaces = 30,
        Address = "Пенза, ул. Пушкина, 4",
        Price = 1500,
        XCoord = 53.195032,
        YCoord = 45.011755
    };

    context.Parkings.Add(parking1);
    context.Parkings.Add(parking2);
    context.SaveChanges();
}

using (var context = new AuthContext(config, true))
{
    var parking = new UserEntity
    {
        Name = "admin",
        Login = "admin",
        Password = "admin",
        CardNumber = "1111111111111111",
        Phone = "+71111111111",
        CarNumber = "Р111РР"
    };

    context.Users.Add(parking);
    context.SaveChanges();
}


