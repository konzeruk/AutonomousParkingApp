
namespace AutonomousParkingApp.StorageCarNumbers.Exceptions;

public class ReservationNotFoundException : StorageCarNumbersException
{
    private const int _statusCode = 404;
    private const string _message = "Бронирование не найдено";

    public ReservationNotFoundException(Dictionary<string, object> data) 
        : base(_statusCode, _message, data)
    {
    }
}
