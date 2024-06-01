using AutonomousParkingApp.Client.Forms.Contracts;
using AutonomousParkingApp.Client.Forms.Helpers;
using AutonomousParkingApp.Client.Models.DTO;
using AutonomousParkingApp.Client.Services;
using AutonomousParkingApp.Client.Services.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class AutorizationContentForm : Form, IEntryContentForm
    {
        private IControlForm _mainContentForm;

        private readonly IAuthService _authService;

        public AutorizationContentForm()
        {
            InitializeComponent();

            textBoxPassword.UseSystemPasswordChar = true;

            _authService = new AuthService();
        }

        public void InstanceForms(IControlForm mainContentForm)
        {
            _mainContentForm = mainContentForm;
        }

        private async void LoginAutoClick_Click(object sender, System.EventArgs e)
        {
            if (textBoxLogin.Text == string.Empty || textBoxPassword.Text == string.Empty)
                MessageBox.Show("Логин или пароль не были введены");

            var user = await _authService.GetUserAsync(new AuthDto
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text
            });

            if (user is null)
                return;
            
            _mainContentForm.ShowControlAndContentForm(user);

            Hide();
        }
    }
}
