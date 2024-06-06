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

        public void InstanceForms(Dictionary<string, ActiveForm> contentForms, IControlForm controlForm)
        {
            _contentForms = contentForms;
            _controlForm = controlForm;
        }

        public void ShowControlAndContentForm(object obj = null)
        {
            Show();

            _contentForms[nameof(EntryContentForm)].ShowActiveForm();

            _contentForms[nameof(AutorizationContentForm)]
                .ToContentForm()
                .InstanceForms(_controlForm);

            _contentForms[nameof(RegistrationContentForm)]
                .ToContentForm()
                .InstanceForms(_controlForm);
        }

        private void bAuth_Click(object sender, EventArgs e)
        {
            LaunchContentAuth();
        }

        private void LaunchContentAuth()
        {
            _contentForms[nameof(EntryContentForm)].CloseActiveForm();
            _contentForms[nameof(RegistrationContentForm)].CloseActiveForm();

            _contentForms[nameof(AutorizationContentForm)].ShowActiveForm();
        }

        private void bReg_Click(object sender, EventArgs e)
        {
            LaunchContentReg();
        }

        private void LaunchContentReg()
        {
            _contentForms[nameof(EntryContentForm)].CloseActiveForm();
            _contentForms[nameof(AutorizationContentForm)].CloseActiveForm();

            _contentForms[nameof(RegistrationContentForm)].ShowActiveForm();
        }
    }
}
