using AutonomousParkingApp.Client.Services.Contracts;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutonomousParkingApp.Client.Models.DTO;
using AutonomousParkingApp.Client.Services.Exceptions;
using AutonomousParkingApp.Client.Services.Utils;
using System.Net;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Services
{
    public class StorageService : IStorageService
    {
        private readonly HttpClient _storageHttpClient;

        public StorageService()
        {
            _storageHttpClient = new HttpClient();
            _storageHttpClient.BaseAddress = new Uri(ServicesConstants.StorageCarNumbers);
        }

        public async Task<ICollection<ParkingDto>> GetAllParkingAsync()
        {
            var result = await _storageHttpClient.GetAsync("all-parking");

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return null;
            }

            return await ServicesUtils.ToDtoAsync<ICollection<ParkingDto>>(result);
        }

        public async Task<PriceDto> GetPriceByUserIdAsync(Guid userId)
        {
            var result = await _storageHttpClient.GetAsync($"price/{userId}");

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return null;
            }

            return await ServicesUtils.ToDtoAsync<PriceDto>(result);
        }

        public async Task<bool> AddReservationAsync(ReservationDto reservation)
        {
            var content = ServicesUtils.ToJsonContent(reservation);

            var result = await _storageHttpClient.PostAsync("add", content);

            if (result.StatusCode != HttpStatusCode.NoContent)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return false;
            }

            return true;
        }

        public async Task<bool> DeleteReservationAsync(Guid userId)
        {
            var result = await _storageHttpClient.DeleteAsync($"delete/{userId}");

            if (result.StatusCode != HttpStatusCode.NoContent)
            {
                var exception = await ServicesUtils.ToDtoAsync<ServiceException>(result);

                ServicesUtils.ShowMessageBoxError(exception);

                return false;
            }

            return true;
        }
    }
}