using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AutonomousParkingApp.Authentication.DB.Models;

[Index(nameof(Login)), Index(nameof(Password))]
public class UserEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Login { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string CarNumber { get; set; }

    public string Phone { get; set; }

    public string CardNumber { get; set; }
}
