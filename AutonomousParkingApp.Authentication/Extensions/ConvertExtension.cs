using AutonomousParkingApp.Authentication.DB.Models;
using AutonomousParkingApp.Authentication.Models.DTO;

namespace AutonomousParkingApp.Authentication.Extensions;

public static class ConvertExtension
{
    public static UserDto ToUserDto(this UserEntity userEntity) =>
        new UserDto
        {
            Name = userEntity.Name,
            Login = userEntity.Login,
            Phone = userEntity.Phone,
            CardNumber = userEntity.CardNumber,
            CarNumber = userEntity.CarNumber
        };

    public static UserEntity ToUserEntity(this UserDto userDto) =>
        new UserEntity
        {
            Name = userDto.Name,
            CardNumber = userDto.CardNumber,
            Phone = userDto.Phone,
            CarNumber = userDto.CarNumber,
            Login = userDto.Login,
        };

    public static UserEntity ToUserEntity(this RegDto authDto) =>
        new UserEntity
        {
            Name = authDto.Name,
            Login = authDto.Login,
            Phone = authDto.Phone,
            CardNumber = authDto.CardNumber,
            CarNumber = authDto.CarNumber,
            Password = authDto.Password
        };
}
