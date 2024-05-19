using AutonomousParkingApp.StorageCarNumbers.Models.DTO;

namespace AutonomousParkingApp.StorageCarNumbers.Services.Contracts;

public interface IStorageCarNumbersService
{
    Task<ICollection<ParkingDto>?> GetAllParkingAsync();

    Task AddReservationAsync(ReservationDto reservationDto);

    Task DeleteReservationAsync(Guid userId);

    Task<PriceDto> GetPriceByUserIdAsync(Guid userId);
}
