namespace AutonomousParkingApp.StorageCarNumbers.Exceptions;

public abstract class StorageCarNumbersException : Exception
{
    public readonly int StatusCode;
    public readonly new string Message;
    public readonly new Dictionary<string, object> Data;

    public StorageCarNumbersException(int statusCode, string message, Dictionary<string, object> data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data; 
    }
}
