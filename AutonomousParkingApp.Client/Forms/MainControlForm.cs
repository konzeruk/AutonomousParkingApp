using AutonomousParkingApp.Client.Forms.Contracts;
using AutonomousParkingApp.Client.Forms.Extensions;
using AutonomousParkingApp.Client.Forms.Helpers;
using AutonomousParkingApp.Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class MainControlForm : Form, IControlForm
    {
        private Dictionary<string, ActiveForm> _contentForms;

        private IControlForm _controlForm;

        public MainControlForm()
        {
            InitializeComponent();
        }

        public void InstanceForms(Dictionary<string, ActiveForm> contentForms, IControlForm controlForm)
        {
            _contentForms = contentForms;
            _controlForm = controlForm;
        }

        public void ShowControlAndContentForm(object obj)
        {
            Show();

            _contentForms[nameof(MyRoomContentForm)]
                .ToMainContentForm()
                .InstanceUser((UserDto)obj);

            _contentForms[nameof(MyRoomContentForm)]
                .ToMainContentForm()
                .InstanceUser((UserDto)obj);

            _contentForms[nameof(MapContentForm)].ShowActiveForm();
        }

        private void bMyRoom_Click(object sender, EventArgs e)
        {
           LaunchContentMyRoom();
        }

        private void LaunchContentMyRoom()
        {
            _contentForms[nameof(MapContentForm)].CloseActiveForm();
            _contentForms[nameof(MyRoomContentForm)].ShowActiveForm();
        }

        private void bMap_Click(object sender, EventArgs e)
        {
            LaunchContentMap();
        }

        private void LaunchContentMap()
        {
            _contentForms[nameof(MyRoomContentForm)].CloseActiveForm();
            _contentForms[nameof(MapContentForm)].ShowActiveForm();

            var myRoomContentForm = _contentForms[nameof(MyRoomContentForm)].ToMainContentForm();

            if (myRoomContentForm.IsEnabledElementControl())
                myRoomContentForm.ChangeEnabledElementControl();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            _contentForms[nameof(MyRoomContentForm)].CloseActiveForm();
            _contentForms[nameof(MapContentForm)].CloseActiveForm();

            _controlForm.ShowControlAndContentForm();

            Hide();
        }
    }
}
