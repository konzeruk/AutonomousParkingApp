using AutonomousParkingApp.Client.Models.DTO;

namespace AutonomousParkingApp.Client.Forms.Contracts
{
    public interface IMainContentForm
    {
        void InstanceUser(UserDto user);

        void ChangeEnabledElementControl();

        bool IsEnabledElementControl();
    }
}
