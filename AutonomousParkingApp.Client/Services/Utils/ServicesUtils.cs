using AutonomousParkingApp.Client.Services.Exceptions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutonomousParkingApp.Client.Services.Utils
{
    public static class ServicesUtils
    {
        public static JsonContent ToJsonContent<T>(T dto) =>
            JsonContent.Create(dto);

        public static async Task<T> ToDtoAsync<T>(HttpResponseMessage httpResponseMessage) =>
            await httpResponseMessage.Content.ReadFromJsonAsync<T>();

        public static void ShowMessageBoxError(ServiceException exception)
        {
            MessageBox.Show($"Error: {exception.Detail}");
        }
    }
}
