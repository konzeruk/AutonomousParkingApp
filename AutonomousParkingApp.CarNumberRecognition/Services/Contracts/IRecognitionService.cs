using AutonomousParkingApp.CarNumberRecognition.Models;

namespace AutonomousParkingApp.CarNumberRecognition.Services.Contracts;

public interface IRecognitionService
{
    CarNumberDto GetCarNumberByImageAsync(ImageDto image);
}
