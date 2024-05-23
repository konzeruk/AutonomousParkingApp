namespace AutonomousParkingApp.Authentication.Exceptions;

public class UserNotFoundException : AuthException
{
    private const int _statusCode = 404;
    private const string _message = "Пользователь не найден";

    public UserNotFoundException(Dictionary<string, object> data)
        : base(_statusCode, _message, data)
    {
    }
}
