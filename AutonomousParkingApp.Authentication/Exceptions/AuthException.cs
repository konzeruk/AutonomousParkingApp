namespace AutonomousParkingApp.Authentication.Exceptions;

public abstract class AuthException : Exception
{
    public readonly int StatusCode;
    public readonly new string Message;
    public readonly new Dictionary<string, object> Data;

    public AuthException(int statusCode, string message, Dictionary<string, object> data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }
}
