using AutonomousParkingApp.Client.Forms.Contracts;
using AutonomousParkingApp.Client.Forms.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutonomousParkingApp.Client.Forms.Extensions;
using System.Threading.Tasks;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class EntryControlForm : Form, IControlForm
    {
        private Dictionary<string, ActiveForm> _contentForms;

        private IControlForm _controlForm;

        public EntryControlForm()
        {
            InitializeComponent();
        }

        public void SendContentForms(Dictionary<string, ActiveForm> contentForms, IControlForm controlForm)
        {
            _contentForms = contentForms;
            _controlForm = controlForm;
        }

        public void ShowControlAndContentForm()
        {
            Show();

            _contentForms[nameof(EntryContentForm)].ShowActiveForm();
        }

        private async void bAuth_Click(object sender, EventArgs e)
        {
            LaunchContentAuth();

            if (await AuthAsync())
                LaunchContolMain();
        }

        private void LaunchContentAuth()
        {
            _contentForms[nameof(EntryContentForm)].CloseActiveForm();
            _contentForms[nameof(RegistrationContentForm)].CloseActiveForm();

            _contentForms[nameof(AutorizationContentForm)].ShowActiveForm();
        }

        private async void bReg_Click(object sender, EventArgs e)
        {
            LaunchContentReg();

            if(await RegistrationAsync())
                LaunchContolMain();
        }

        private void LaunchContentReg()
        {
            _contentForms[nameof(EntryContentForm)].CloseActiveForm();
            _contentForms[nameof(AutorizationContentForm)].CloseActiveForm();

            _contentForms[nameof(RegistrationContentForm)].ShowActiveForm();
        }

        private Task<bool> RegistrationAsync()
        {
            return Task.FromResult(true);
        }

        private Task<bool> AuthAsync()
        {
            return Task.FromResult(true);
        }

        private void LaunchContolMain()
        {
            _contentForms[nameof(RegistrationContentForm)].CloseActiveForm();
            _contentForms[nameof(AutorizationContentForm)].CloseActiveForm();

            _controlForm.ShowControlAndContentForm();

            Hide();
        }
    }
}
