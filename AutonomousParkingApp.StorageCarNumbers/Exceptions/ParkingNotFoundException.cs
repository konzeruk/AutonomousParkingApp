using Microsoft.AspNetCore.Http;

namespace AutonomousParkingApp.StorageCarNumbers.Exceptions
{
    public class ParkingNotFoundException : StorageCarNumbersException
    {
        private const int _statusCode = 404;
        private const string _message = "Парковка не найдено";

        public ParkingNotFoundException(Dictionary<string, object> data)
            : base(_statusCode, _message, data)
        {
        }
    }
}
