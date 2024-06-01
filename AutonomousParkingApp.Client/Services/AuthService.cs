using AutonomousParkingApp.Client.Models.DTO;
using AutonomousParkingApp.Client.Services.Contracts;
using AutonomousParkingApp.Client.Services.Exceptions;
using AutonomousParkingApp.Client.Services.Utils;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _authHttpClient;

        public AuthService()
        {
            _authHttpClient = new HttpClient();
            _authHttpClient.BaseAddress = new Uri(ServicesConstants.AuthService);
        }

        public async Task<bool> AddUserAsync(RegDto user)
        {
            var content = ServicesUtils.ToJsonContent(user);

            var result = await _authHttpClient.PostAsync("add-user", content);

            if (result.StatusCode != HttpStatusCode.NoContent)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return false;
            }

            return true;
        }

        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            var content = ServicesUtils.ToJsonContent(user);

            var result = await _authHttpClient.PutAsync("update-user", content);

            if (result.StatusCode != HttpStatusCode.NoContent)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return false;
            }

            return true;
        }

        public async Task<UserDto> GetUserByUserIdAsync(Guid userId)
        {
            var result = await _authHttpClient.GetAsync($"get-user/{userId}");

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return null;
            }

            return await ServicesUtils.ToDtoAsync<UserDto>(result);
        }

        public async Task<UserDto> GetUserAsync(AuthDto authDto)
        {
            var content = ServicesUtils.ToJsonContent(authDto);

            var result = await _authHttpClient.PostAsync("get-user-by-login-password", content);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return null;
            }

            return await ServicesUtils.ToDtoAsync<UserDto>(result);
        }

        public async Task<Guid?> GetUserIdByLoginAsync(string login)
        {
            var result = await _authHttpClient.GetAsync($"get-userId-by-login/{login}");

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return null;
            }

            return await ServicesUtils.ToDtoAsync<Guid>(result);
        }
    }
}
