using AutonomousParkingApp.StorageCarNumbers.DB.Contexts;
using AutonomousParkingApp.StorageCarNumbers.DB.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutonomousParkingApp.StorageCarNumbers.DB.Repositories;

public class StorageCarNumbersRepository
{
    private readonly StorageCarNumbersContext _storageCarNumbersContext;

    public StorageCarNumbersRepository(StorageCarNumbersContext storageCarNumbersContext)
    {
        _storageCarNumbersContext = storageCarNumbersContext;
    }

    public async Task<ReservationEntity?> GetReservationByUserIdAsync(Guid userId) =>
        await _storageCarNumbersContext.Reservations
            .FirstOrDefaultAsync(x => x.UserId == userId);

    public async Task<ICollection<ReservationEntity>?> GetReservationByParkingIdAsync(Guid parkingId) =>
        await _storageCarNumbersContext.Reservations
            .Where(x=>x.ParkingId == parkingId)
            .ToListAsync();

    public async Task AddReservationAsync(ReservationEntity reservation)
    {
        await _storageCarNumbersContext.Reservations
            .AddAsync(reservation);

        await _storageCarNumbersContext
            .SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(ReservationEntity reservation)
    {
        _storageCarNumbersContext.Reservations
            .Remove(reservation);

        await _storageCarNumbersContext
            .SaveChangesAsync();
    }

    public async Task<ICollection<ParkingEntity>?> GetAllParkingAsync() =>
        await _storageCarNumbersContext.Parkings
            .ToListAsync();

    public async Task<int> GetNumFreeSpacesByParkingIdAsync(Guid parkingId) =>
        (await _storageCarNumbersContext.Parkings
            .FirstOrDefaultAsync(x => x.Id == parkingId))!
            .NumFreeSpaces;

    public async Task<ParkingEntity?> GetParkingByParkingIdAsync(Guid parkingId) =>
        await _storageCarNumbersContext.Parkings
            .FirstOrDefaultAsync(x=>x.Id == parkingId);

    public async Task UpdateParkingAsync(ParkingEntity parking)
    {
        _storageCarNumbersContext.Parkings
            .Update(parking);

        await _storageCarNumbersContext
            .SaveChangesAsync();
    }

    public async Task<int> GetPriceByParkingIdAsync(Guid parkingId) =>
        (await _storageCarNumbersContext.Parkings
            .FirstOrDefaultAsync(x => x.Id == parkingId))!
            .Price;
}