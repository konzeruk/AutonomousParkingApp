
namespace AutonomousParkingApp.Authentication.Exceptions
{
    public class UserExistException : AuthException
    {
        private const int _statusCode = 201;
        private const string _message = "Пользователь с таким именем уже существует";

        public UserExistException(Dictionary<string, object> data) 
            : base(_statusCode, _message, data)
        {
        }
    }
}
