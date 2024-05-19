namespace AutonomousParkingApp.CarNumberRecognition.Exceptions
{
    public abstract class CarNumbersRecognitionException : Exception
    {
        public readonly int StatusCode;
        public readonly new string Message;
        public readonly new Dictionary<string, object> Data;

        public CarNumbersRecognitionException(int statusCode, string message, Dictionary<string, object> data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
