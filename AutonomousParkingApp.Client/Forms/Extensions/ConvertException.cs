using AutonomousParkingApp.Client.Models.DTO;

namespace AutonomousParkingApp.Client.Forms.Extensions
{
    public static class ConvertException
    {
        public static UserDto ToUserDto(this RegDto reg) =>
            new UserDto
            {
                CardNumber = reg.CardNumber,
                CarNumber = reg.CarNumber,
                Login = reg.Login,
                Name = reg.Name,
                Phone = reg.Phone,
            };
    }
}
