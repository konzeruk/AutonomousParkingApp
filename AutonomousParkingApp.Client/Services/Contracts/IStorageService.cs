using AutonomousParkingApp.Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutonomousParkingApp.Client.Services.Contracts
{
    public interface IStorageService
    {
        Task<ICollection<ParkingDto>> GetAllParkingAsync();

        Task<PriceDto> GetPriceByUserIdAsync(Guid userId);

        Task<bool> AddReservationAsync(ReservationDto reservation);

        Task<bool> DeleteReservationAsync(Guid userId);
    }
}