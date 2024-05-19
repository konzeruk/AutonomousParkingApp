using AutonomousParkingApp.StorageCarNumbers.DB.Contexts;
using AutonomousParkingApp.StorageCarNumbers.DB.Repositories;
using AutonomousParkingApp.StorageCarNumbers.Services;
using AutonomousParkingApp.StorageCarNumbers.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddScoped<StorageCarNumbersContext>();
services.AddScoped<StorageCarNumbersRepository>();
services.AddScoped<IStorageCarNumbersService, StorageCarNumbersService>();

var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json");

app.UseAuthorization();

app.MapControllers();

app.Run();
