using AutonomousParkingApp.Authentication.DB.Contexts;
using AutonomousParkingApp.Authentication.DB.Repositories;
using AutonomousParkingApp.Authentication.Services;
using AutonomousParkingApp.Authentication.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddScoped<AuthContext>();
services.AddScoped<AuthRepository>();
services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json");

app.MapControllers();

app.Run();
