using AutonomousParkingApp.Client.Services.Contracts;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using AutonomousParkingApp.Client.Models.DTO;
using AutonomousParkingApp.Client.Services.Utils;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Collections;

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
            const int countNumber = 6;

            //var result = await _numberRecognitionHttpClient.PostAsync(ServicesConstants.PyNumberRecognition, new StringContent(ByteArrayToJson(image.Data), Encoding.UTF8, "application/json"));
            var result = await _numberRecognitionHttpClient.GetAsync($"{ServicesConstants.PyNumberRecognition}?file={image.FileName}");

            if (result.Content is null)
            {
                MessageBox.Show("Номер не распознан, сделайте, пожалуйста, более чёткое изображение");

                return null;
            }

            var number = (await result.Content.ReadAsStringAsync()).Substring(0, countNumber);

            return number;
        }

        private string ByteArrayToJson(byte[,] image)
        {
            var intArray = new int[image.GetLength(0), image.GetLength(1)];
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    intArray[i, j] = image[i, j];
                }
            }

            return JsonConvert.SerializeObject(intArray);
        }
    }
}
