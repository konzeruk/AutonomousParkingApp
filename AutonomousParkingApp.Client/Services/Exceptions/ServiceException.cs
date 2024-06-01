using System.Collections.Generic;

namespace AutonomousParkingApp.Client.Services.Exceptions
{
    public class ServiceException
    {
        public string Detail { get; set; }

        public string Instance { get; set; }

        public int? StatusCode { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }
    }
}
