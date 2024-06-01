using AutonomousParkingApp.Client.Forms.Contracts;
using AutonomousParkingApp.Client.Models.DTO;
using AutonomousParkingApp.Client.Services;
using AutonomousParkingApp.Client.Services.Contracts;
using AutonomousParkingApp.Client.Forms.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AutonomousParkingApp.Client.Forms.Helpers.Constants;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class RegistrationContentForm : Form, IEntryContentForm
    {
        private IControlForm _mainContentForm;

        private readonly IAuthService _authService;

        public RegistrationContentForm()
        {
            InitializeComponent();

            _authService = new AuthService();
        }

        public void InstanceForms(IControlForm mainContentForm)
        {
            _mainContentForm = mainContentForm;
        }

        private async void bReg_Click(object sender, EventArgs e)
        {
            var regDto = GetEnterData();
            if (regDto is null)
            {
                MessageBox.Show("Error: Данные были введены не корректно");
                return;
            }

            if (!await _authService.AddUserAsync(regDto))
                return;

            _mainContentForm.ShowControlAndContentForm(regDto.ToUserDto());

            Hide();
        }

        private RegDto GetEnterData()
        {
            var textBoxes = new Dictionary<string, TextBox>
            {
                { nameof(textBoxLogin), textBoxLogin },
                { nameof(textBoxPassword), textBoxPassword },
                { nameof(textBoxFIO), textBoxFIO },
                { nameof(textBoxCarNumber), textBoxCarNumber },
                { nameof(textBoxPhone), textBoxPhone },
                { nameof(textBoxCardNumber), textBoxCardNumber },
            };

            if (!CheckEnterData(textBoxes))
                return null;

            return new RegDto
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
                Name = textBoxFIO.Text,
                CardNumber = textBoxCardNumber.Text,
                CarNumber = textBoxCarNumber.Text,
                Phone = textBoxPhone.Text,
            };
        }

        private bool CheckEnterData(Dictionary<string, TextBox> textBoxes)
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
    }
}
