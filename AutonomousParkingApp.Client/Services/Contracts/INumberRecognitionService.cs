using AutonomousParkingApp.Client.Models.DTO;
using System.Threading.Tasks;

namespace AutonomousParkingApp.Client.Services.Contracts
{
    public interface INumberRecognitionService
    {
        Task<string> GetCarNumberAsync(ImageDto image);
    }
}
