using AutonomousParkingApp.Client.Models.DTO;
using System;
using System.Threading.Tasks;

namespace AutonomousParkingApp.Client.Services.Contracts
{
    public interface IAuthService
    {
        Task<bool> AddUserAsync(RegDto user);

        Task<bool> UpdateUserAsync(UserDto user);

        Task<UserDto> GetUserByUserIdAsync(Guid userId);

        Task<UserDto> GetUserAsync(AuthDto authDto);

        Task<Guid?> GetUserIdByLoginAsync(string login);
    }
}
