﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutonomousParkingApp.StorageCarNumbers.DB.Models.Entities;

public class ParkingEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    public string Address { get; set; }

    public int Price { get; set; }

    public int NumFreeSpaces { get; set; }

    public int XCoord { get; set; }

    public int YCoord { get; set; }
}
