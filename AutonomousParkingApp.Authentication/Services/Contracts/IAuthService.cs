using AutonomousParkingApp.Authentication.Models.DTO;

namespace AutonomousParkingApp.Authentication.Services.Contracts;

public interface IAuthService
{
    Task AddUserAsync(UserForAuthDto user);

    Task UpdateUserAsync(UserDto user);

    Task<UserDto> GetUserByUserIdAsync(Guid userId);

    Task<UserDto> GetUserByPasswordAsync(string password);

    Task<Guid> GetUserIdByLoginAsync(string login);
}
