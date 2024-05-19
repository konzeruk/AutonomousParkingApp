using AutonomousParkingApp.CarNumberRecognition.Services;
using AutonomousParkingApp.CarNumberRecognition.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddScoped<IRecognitionService, RecognitionService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
