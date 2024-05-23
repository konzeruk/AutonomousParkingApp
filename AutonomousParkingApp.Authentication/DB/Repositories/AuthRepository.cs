using AutonomousParkingApp.Authentication.DB.Contexts;
using AutonomousParkingApp.Authentication.DB.Models;
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

    public async Task<UserEntity?> GetUserByPasswordAsync(string password) =>
        await _authContext.Users
            .FirstOrDefaultAsync(x => x.Password == password);

    public async Task<UserEntity?> GetUserByLoginAsync(string login) =>
        await _authContext.Users
            .FirstOrDefaultAsync(x => x.Login == login);
}
