using AutonomousParkingApp.Client.Forms.Helpers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Forms.Contracts
{
    public interface IControlForm
    {
        void InstanceForms(Dictionary<string, ActiveForm> contentForms, IControlForm controlForm);

        void ShowControlAndContentForm(object obj = null);
    }
}
