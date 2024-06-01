using AutonomousParkingApp.Authentication.Models.DTO;

namespace AutonomousParkingApp.Authentication.Services.Contracts;

public interface IAuthService
{
    Task AddUserAsync(RegDto user);

    Task UpdateUserAsync(UserDto user);

    Task<UserDto> GetUserByUserIdAsync(Guid userId);

    Task<UserDto> GetUserAsync(AuthDto authDto);

    Task<Guid> GetUserIdByLoginAsync(string login);
}
