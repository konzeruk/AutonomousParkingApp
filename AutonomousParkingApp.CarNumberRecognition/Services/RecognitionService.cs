using AutonomousParkingApp.CarNumberRecognition.Exceptions;
using AutonomousParkingApp.CarNumberRecognition.Models;
using AutonomousParkingApp.CarNumberRecognition.Services.Contracts;
using Python.Runtime;

namespace AutonomousParkingApp.CarNumberRecognition.Services;

public class RecognitionService : IRecognitionService
{
    public const string scriptName = @"D:\Code\AutonomousParkingApp\PyNumberRecognition\PyNumberRecognition.py";
    public const string get_number_car = nameof(get_number_car);

    public RecognitionService()
    {
        try
        {
            // Runtime.PythonDLL = @"C:\Users\konze\anaconda3\python311.dll";
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", @"C:\Users\konze\anaconda3\python311.dll");
            Environment.SetEnvironmentVariable("PYTHONHOME", @"C:\Users\konze\anaconda3");
            PythonEngine.Initialize();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }

    public CarNumberDto GetCarNumberByImageAsync(ImageDto image)
    {
        using (Py.GIL())
        {
            var pythonScript = Py.Import(scriptName);

            var result = (pythonScript.InvokeMethod(get_number_car, new PyObject[] { image.Image.ToPython() })).ToString();

            PythonEngine.Shutdown();

            if (string.IsNullOrEmpty(result))
                throw new NumbersNotRecognitionException(new Dictionary<string, object> { { nameof(image), image } });

            return new CarNumberDto
            {
                CarNumber = result.ToString()!
            };
        }
    }
}
