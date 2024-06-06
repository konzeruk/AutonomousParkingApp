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
using System.Drawing;
using System.Drawing.Imaging;

namespace AutonomousParkingApp.Client.Forms
{
    public partial class RegistrationContentForm : Form, IEntryContentForm
    {
        private IControlForm _mainContentForm;

        private readonly IAuthService _authService;
        private readonly INumberRecognitionService _numberRecognitionService;

        public RegistrationContentForm()
        {
            InitializeComponent();

            _authService = new AuthService();
            _numberRecognitionService = new NumberRecognitionService();

            openImageDialog.Filter = "Image file (*.jpg)|*.jpg|*.jpeg|*.png";
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

        private async void bLoadCarNumber_Click(object sender, EventArgs e)
        {
            if (openImageDialog.ShowDialog() == DialogResult.Cancel)
                return;

            var fileName = openImageDialog.FileName;

            var bitmap = new Bitmap(fileName);

            var image = BitmapConvertToArray(bitmap);

            var number = await _numberRecognitionService.GetCarNumberAsync(new ImageDto { FileName = fileName });
            
            if(number == null)
                return;

            textBoxCarNumber.Text = number;
        }

        private byte[,] BitmapConvertToArray(Bitmap bitmap)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, bitmap.PixelFormat);
            
            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            bitmap.UnlockBits(bmpData);

            byte[,] result = new byte[bitmap.Height, bitmap.Width];

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    int index = i * bmpData.Stride + j * 3;
                    result[i, j] = rgbValues[index];
                }
            }

            return result;
        }
    }
}
