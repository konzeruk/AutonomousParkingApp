namespace AutonomousParkingApp.StorageCarNumbers.Exceptions
{
    public class NumFreeSpecesEquelsNullException : StorageCarNumbersException
    {
        private const int _statusCode = 201;
        private const string _message = "Места на парковке отсутствуют";

        public NumFreeSpecesEquelsNullException(Dictionary<string, object> data)
            : base(_statusCode, _message, data)
        {
        }
    }
}
