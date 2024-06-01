﻿namespace AutonomousParkingApp.Client.Models.DTO
{
    public class ParkingDto
    {
        public string Address { get; set; }

        public int Price { get; set; }

        public int NumFreeSpaces { get; set; }

        public int XCoord { get; set; }

        public int YCoord { get; set; }
    }
}