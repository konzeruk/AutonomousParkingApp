using AutonomousParkingApp.Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomousParkingApp.Client.Forms.Extensions
{
    public static class DtoException
    {
        public static bool Compare(this UserDto userDto, UserDto _userDto) =>
            userDto.Equals(_userDto);
    }
}
