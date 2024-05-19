using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AutonomousParkingApp.StorageCarNumbers.DB.Models.Entities;

[Index(nameof(UserId)), Index(nameof(ParkingId))]
public class ReservationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid ParkingId { get; set; }

    public Guid UserId { get; set; }

    public DateTime CheckInTime { get; set; }
}