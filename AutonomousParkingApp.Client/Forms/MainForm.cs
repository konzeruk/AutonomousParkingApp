using AutonomousParkingApp.Client.Forms;
using AutonomousParkingApp.Client.Forms.Helpers.Constants;
using AutonomousParkingApp.Client.Forms.Helpers;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            AddFormToPanel();
        }

        private void AddFormToPanel()
        {
            var entryContentForm = LoadPanelForm<EntryContentForm>(FormConstants.Content);
            var authContentForm = LoadPanelForm<AutorizationContentForm>(FormConstants.Content);
            var regContentForm = LoadPanelForm<RegistrationContentForm>(FormConstants.Content);
            var myRoomContentForm = LoadPanelForm<MyRoomContentForm>(FormConstants.Content);
            var mapContentForm = LoadPanelForm<MapContentForm>(FormConstants.Content);

            var mainControlForm = LoadPanelForm<MainControlForm>(FormConstants.Control);
            var entryControlForm = LoadPanelForm<EntryControlForm>(FormConstants.Control);
            entryControlForm.InstanceForms(new Dictionary<string, ActiveForm>
            {
                {
                    nameof(EntryContentForm),
                    new ActiveForm { InitForm= entryContentForm }
                },
                {
                    nameof(AutorizationContentForm),
                    new ActiveForm { InitForm = authContentForm}
                },
                {
                    nameof(RegistrationContentForm),
                    new ActiveForm { InitForm = regContentForm }
                }
            }, mainControlForm);

            entryControlForm.ShowControlAndContentForm();

            mainControlForm.InstanceForms(new Dictionary<string, ActiveForm>
            {
                {
                    nameof(MapContentForm),
                    new ActiveForm { InitForm = mapContentForm }
                },
                {
                    nameof(MyRoomContentForm),
                    new ActiveForm { InitForm = myRoomContentForm }
                }
            }, entryControlForm);
        }

        private TForm LoadPanelForm<TForm> (string panel)
            where TForm : Form, new()
        {
            var form = new TForm ();
            SettingLoadForm(form);

            if (panel.Equals(FormConstants.Control))
                panelControl.Controls.Add(form);

            if(panel.Equals(FormConstants.Content))
                panelContent.Controls.Add(form);

            return form;
        }

        private void SettingLoadForm<TForm>(TForm form)
            where TForm : Form
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
