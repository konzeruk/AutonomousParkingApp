﻿using AutonomousParkingApp.Authentication.DB.Models;
using AutonomousParkingApp.Authentication.DB.Repositories;
using AutonomousParkingApp.Authentication.Exceptions;
using AutonomousParkingApp.Authentication.Extensions;
using AutonomousParkingApp.Authentication.Models.DTO;
using AutonomousParkingApp.Authentication.Services.Contracts;

namespace AutonomousParkingApp.Authentication.Services;

public class AuthService : IAuthService
{
    public readonly AuthRepository _authRepository;

    public AuthService(AuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task AddUserAsync(UserForAuthDto user)
    {
        var findUser = await _authRepository.GetUserByLoginAsync(user.Login);

        if(findUser is not null)
            throw new UserExistException(new Dictionary<string, object> { { nameof(user), user } });

        await _authRepository.AddUserAsync(user.ToUserEntity());
    }

    public async Task UpdateUserAsync(UserDto user)
    {
        var findUser = await _authRepository.GetUserByLoginAsync(user.Login);

        if (findUser is null)
            throw new UserNotFoundException(new Dictionary<string, object> { { nameof(user), user } });

        findUser.Login = user.Login;
        findUser.Name = user.Name;
        findUser.CarNumber = user.CarNumber;
        findUser.Phone = user.Phone;
        findUser.CardNumber = user.CardNumber;

        await _authRepository.UpdateUserAsync(findUser);
    }

    public async Task<UserDto> GetUserByUserIdAsync(Guid userId)
    {
        var user = await _authRepository.GetUserByIdAsync(userId);

        if (user is null)
            throw new UserNotFoundException(new Dictionary<string, object> { { nameof(userId), userId } });

        return user.ToUserDto();
    }

    public async Task<UserDto> GetUserByPasswordAsync(string password)
    {
        var user = await _authRepository.GetUserByPasswordAsync(password);

        if (user is null)
            throw new UserNotFoundException(new Dictionary<string, object> { { nameof(password), password } });

        return user.ToUserDto();
    }

    public async Task<Guid> GetUserIdByLoginAsync(string login)
    {
        var user = await _authRepository.GetUserByLoginAsync(login);

        if (user is null)
            throw new UserNotFoundException(new Dictionary<string, object> { { nameof(login), login } });

        return user.Id;
    }
}
