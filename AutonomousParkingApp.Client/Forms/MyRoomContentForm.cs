using AutonomousParkingApp.Client.Forms.Contracts;
using AutonomousParkingApp.Client.Forms.Extensions;
using AutonomousParkingApp.Client.Forms.Helpers;
using AutonomousParkingApp.Client.Forms.Helpers.Constants;
using AutonomousParkingApp.Client.Models.DTO;
using AutonomousParkingApp.Client.Services;
using AutonomousParkingApp.Client.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class MyRoomContentForm : Form, IMainContentForm
    {
        private UserDto _user;
        private bool isEnabled = false;

        private readonly IAuthService _authService;

        public MyRoomContentForm()
        {
            InitializeComponent();

            _authService = new AuthService();
        }

        public void InstanceUser(UserDto user)
        {
            _user = user;

            InitUserData();
        }

        private void InitUserData()
        {
            textBoxFIO.Text = _user.Name;
            textBoxPhone.Text = _user.Phone;
            textBoxCarNumber.Text = _user.CarNumber;
            textBoxCardNumber.Text = _user.CardNumber;
        }

        private async void bSave_Click(object sender, EventArgs e)
        {
            var changeUser = GetChangeUserData();

            if (changeUser == null)
                return;

            var result = await _authService.UpdateUserAsync(changeUser);

            if(result)
                _user = changeUser;

            InitUserData();

            ChangeEnabledElementControl();
        }

        private void bChange_Click(object sender, EventArgs e)
        {
            ChangeEnabledElementControl();
        }

        private UserDto GetChangeUserData()
        {
            var textBoxes = new Dictionary<string, TextBox>
            {
                { nameof(textBoxFIO), textBoxFIO },
                { nameof(textBoxCarNumber), textBoxCarNumber },
                { nameof(textBoxPhone), textBoxPhone },
                { nameof(textBoxCardNumber), textBoxCardNumber },
            };

            if (!CheckChangeData(textBoxes))
            {
                MessageBox.Show("Error: Данные введены не верно");
                return null;
            }

            var changeUser = new UserDto
            {
                Login = _user.Login,
                Name = textBoxFIO.Text,
                Phone = textBoxPhone.Text,
                CarNumber = textBoxCarNumber.Text,
                CardNumber = textBoxCardNumber.Text
            };

            if (!CheckCompare(changeUser))
            {
                MessageBox.Show("Error: Данные не были изменены");
                return null;
            }

            return changeUser;
        }

        private bool CheckChangeData(Dictionary<string, TextBox> textBoxes)
        {
            foreach (var textBox in textBoxes)
                if (textBox.Value.Text == string.Empty)
                    return false;

            if (!CheckEnterPhone(textBoxes[nameof(textBoxPhone)].Text) || !CheckEnterCardNumber(textBoxes[nameof(textBoxCardNumber)].Text))
                return false;

            return true;
        }

        private bool CheckEnterPhone(string phone) =>
            Regex.IsMatch(phone, FormConstants.RegexPhone);

        private bool CheckEnterCardNumber(string cardNumber) =>
            Regex.IsMatch(cardNumber, FormConstants.RegexCardNumber);

        private bool CheckCompare(UserDto user) =>
            !_user.Compare(user);

        public void ChangeEnabledElementControl()
        {
            textBoxFIO.Enabled = !textBoxFIO.Enabled;
            textBoxPhone.Enabled = !textBoxPhone.Enabled;
            textBoxCarNumber.Enabled = !textBoxCarNumber.Enabled;
            textBoxCardNumber.Enabled = !textBoxCardNumber.Enabled;
            bSave.Enabled = !bSave.Enabled;

            isEnabled = !isEnabled;
        }

        public bool IsEnabledElementControl() =>
            isEnabled;
    }
}
