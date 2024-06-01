using AutonomousParkingApp.Client.Services.Contracts;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using AutonomousParkingApp.Client.Models.DTO;
using AutonomousParkingApp.Client.Services.Utils;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Services
{
    public class NumberRecognitionService : INumberRecognitionService
    {
        private readonly HttpClient _numberRecognitionHttpClient;

        public NumberRecognitionService()
        {
            _numberRecognitionHttpClient = new HttpClient();
        }

        public async Task<string> GetCarNumberAsync(ImageDto image)
        {
            var result = await _numberRecognitionHttpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(ServicesConstants.PyNumberRecognition),
                Content = ServicesUtils.ToJsonContent(image)
            });

            if(result.Content == null)
            {
                var messageException = "Номер не распознан, сделайте, пожалуйста, более чёткое изображение";

                MessageBox.Show(messageException);
            }

            return result.Content.ToString();
        }
    }
}
