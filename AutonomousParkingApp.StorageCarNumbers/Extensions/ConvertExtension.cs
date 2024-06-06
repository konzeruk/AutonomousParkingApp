using AutonomousParkingApp.StorageCarNumbers.DB.Models.Entities;
using AutonomousParkingApp.StorageCarNumbers.Models.DTO;

namespace AutonomousParkingApp.StorageCarNumbers.Extensions;

public static class ConvertExtension
{
    public static ParkingDto ToParkingDto(this ParkingEntity parkingEntity) =>
        new ParkingDto
        {
            ParkingId = parkingEntity.Id,
            Price = parkingEntity.Price,
            Address = parkingEntity.Address,
            NumFreeSpaces = parkingEntity.NumFreeSpaces,
            XCoord = parkingEntity.XCoord,
            YCoord = parkingEntity.YCoord,
        };

    public static ParkingEntity ToParkingEntity(this ParkingDto parkingDto) =>
        new ParkingEntity
        {
            Price = parkingDto.Price,
            Address = parkingDto.Address,
            NumFreeSpaces = parkingDto.NumFreeSpaces
        };

    public static ReservationDto ToReservationDto(this ReservationEntity reservationEntity) =>
        new ReservationDto
        {
            UserId = reservationEntity.UserId,
            ParkingId = reservationEntity.ParkingId,
            CheckInTime = reservationEntity.CheckInTime,
        };

    public static ReservationEntity ToReservationEntity(this ReservationDto reservationDto) =>
        new ReservationEntity
        {
            UserId = reservationDto.UserId,
            ParkingId = reservationDto.ParkingId,
            CheckInTime = reservationDto.CheckInTime
        };
}
