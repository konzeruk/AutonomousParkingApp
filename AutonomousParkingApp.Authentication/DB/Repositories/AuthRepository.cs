using AutonomousParkingApp.Authentication.DB.Contexts;
using AutonomousParkingApp.Authentication.DB.Models;
using AutonomousParkingApp.Authentication.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace AutonomousParkingApp.Authentication.DB.Repositories;

public class AuthRepository
{
    private readonly AuthContext _authContext;

    public AuthRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }

    public async Task AddUserAsync(UserEntity user)
    {
        _authContext.Users.Add(user);

        await _authContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(UserEntity user)
    {
        _authContext.Users.Update(user);

        await _authContext.SaveChangesAsync();
    }

    public async Task<UserEntity?> GetUserByIdAsync(Guid userId) =>
        await _authContext.Users
            .FirstOrDefaultAsync(x => x.Id == userId);

    public async Task<UserEntity?> GetUserAsync(string login, string password) =>
        await _authContext.Users
            .FirstOrDefaultAsync(x => x.Login.Equals(login) && x.Password.Equals(password));

    public async Task<UserEntity?> GetUserByLoginAsync(string login) =>
        await _authContext.Users
            .FirstOrDefaultAsync(x => x.Login.Equals(login));
}
