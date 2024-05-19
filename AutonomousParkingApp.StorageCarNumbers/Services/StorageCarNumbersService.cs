using AutonomousParkingApp.StorageCarNumbers.DB.Repositories;
using AutonomousParkingApp.StorageCarNumbers.Exceptions;
using AutonomousParkingApp.StorageCarNumbers.Extensions;
using AutonomousParkingApp.StorageCarNumbers.Models.DTO;
using AutonomousParkingApp.StorageCarNumbers.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;

namespace AutonomousParkingApp.StorageCarNumbers.Services;

public class StorageCarNumbersService : IStorageCarNumbersService
{
    private readonly StorageCarNumbersRepository _storageCarNumbersRepository;

    public StorageCarNumbersService(StorageCarNumbersRepository storageCarNumbersRepository)
    {
        _storageCarNumbersRepository = storageCarNumbersRepository;
    }

    public async Task<ICollection<ParkingDto>?> GetAllParkingAsync()
    {
        var parkings = await _storageCarNumbersRepository.GetAllParkingAsync()
            ?? throw new ParkingNotFoundException(new Dictionary<string, object> { { nameof(ParkingDto), string.Empty } });
       
        var result = new List<ParkingDto>();

        foreach (var parking in parkings)
            result.Add(parking.ToParkingDto());

        return result;
    }

    public async Task AddReservationAsync(ReservationDto reservationDto)
    {
        var parking = await _storageCarNumbersRepository.GetParkingByParkingIdAsync(reservationDto.ParkingId)
            ?? throw new ParkingNotFoundException(new Dictionary<string, object> { { nameof(reservationDto), reservationDto } });

        if (parking.NumFreeSpaces <= 0)
            throw new NumFreeSpecesEquelsNullException(new Dictionary<string, object> { { nameof(reservationDto), reservationDto } });

        parking.NumFreeSpaces -= 1;

        await _storageCarNumbersRepository.UpdateParkingAsync(parking);

        await _storageCarNumbersRepository.AddReservationAsync(reservationDto.ToReservationEntity());
    }

    public async Task DeleteReservationAsync(Guid userId)
    {
        var reservation = await _storageCarNumbersRepository.GetReservationByUserIdAsync(userId)
            ?? throw new ReservationNotFoundException(new Dictionary<string, object> { { nameof(userId), userId } });

        await _storageCarNumbersRepository.DeleteReservationAsync(reservation);

        var parking = await _storageCarNumbersRepository.GetParkingByParkingIdAsync(reservation.ParkingId);

        parking!.NumFreeSpaces += 1;

        await _storageCarNumbersRepository.UpdateParkingAsync(parking);
    }

    public async Task<PriceDto> GetPriceByUserIdAsync(Guid userId)
    {
        var reservation = await _storageCarNumbersRepository.GetReservationByUserIdAsync(userId)
            ?? throw new ReservationNotFoundException(new Dictionary<string, object> { { nameof(userId), userId } });

        var nowDate = DateTime.Now;
        var checkInTime = reservation.CheckInTime;

        var countDay = (nowDate.Day < checkInTime.Day)
            ? (30 - checkInTime.Day) + nowDate.Day   
            : nowDate.Day - checkInTime.Day;

        var countHour = ((nowDate.Hour < checkInTime.Hour)
            ? (24 - checkInTime.Hour) + nowDate.Hour
            : nowDate.Hour - checkInTime.Hour)
            + (countDay * 24 * 60);

        var countMinute = (nowDate.Minute < checkInTime.Minute)
            ? (60 - checkInTime.Minute) + nowDate.Minute
            : nowDate.Minute - checkInTime.Minute;

        var pricePerHour = await _storageCarNumbersRepository.GetPriceByParkingIdAsync(reservation.ParkingId);
        var price = Math.Round(pricePerHour * Convert.ToDecimal(countHour + (countMinute/60.0)), 2);

        return new PriceDto
        {
            NumHour = countHour,
            NumMinute = countMinute,
            Price = price,
        };
    }
}
