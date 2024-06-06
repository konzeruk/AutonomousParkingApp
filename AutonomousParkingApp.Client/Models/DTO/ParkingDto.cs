using System;

namespace AutonomousParkingApp.Client.Models.DTO
{
    public class ParkingDto
    {
        public Guid ParkingId { get; set; }

        public string Address { get; set; }

        public int Price { get; set; }

        public int NumFreeSpaces { get; set; }

        public double XCoord { get; set; }

        public double YCoord { get; set; }
    }
}
