using AutonomousParkingApp.CarNumberRecognition.Models;
using AutonomousParkingApp.CarNumberRecognition.Services.Contracts;
using Python.Runtime;

namespace AutonomousParkingApp.CarNumberRecognition.Services;

public class RecognitionService : IRecognitionService
{
    public const string scriptName = "PyNumberRecognition.py";
    public const string get_number_car = nameof(get_number_car);

    public RecognitionService()
    {
        Runtime.PythonDLL = @"C:\Users\konze\anaconda3\python311.dll";
        PythonEngine.Initialize();
    }

    public CarNumberDto GetCarNumberByImageAsync(ImageDto image)
    {
        using (Py.GIL())
        {
            var pythonScript = Py.Import(scriptName);

            dynamic np = Py.Import("numpy");

            var arg = 



            var result = pythonScript.InvokeMethod(get_number_car, new PyObject {image.Image});


        }
    }

    private PyList ArrayByteToPyList
}
