
namespace AutonomousParkingApp.CarNumberRecognition.Exceptions
{
    public class NumbersNotRecognitionException : CarNumbersRecognitionException
    {
        private const int _statusCode = 201;
        private const string _message = "Не удалось распознать номер автомобиля";

        public NumbersNotRecognitionException(Dictionary<string, object> data) 
            : base(_statusCode, _message, data)
        {
        }
    }
}
