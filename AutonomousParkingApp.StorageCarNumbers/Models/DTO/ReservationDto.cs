namespace AutonomousParkingApp.StorageCarNumbers.Models.DTO
{
    public class ReservationDto
    {
        public Guid ParkingId { get; set; }

        public Guid UserId { get; set; }

        public DateTime CheckInTime { get; set; }
    }
}
