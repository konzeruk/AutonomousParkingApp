using AutonomousParkingApp.CarNumberRecognition.Models;
using AutonomousParkingApp.CarNumberRecognition.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Runtime.InteropServices;


namespace AutonomousParkingApp.CarNumberRecognition.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecognitionController : ControllerBase
{
    public readonly IRecognitionService _recognitionService;

    public RecognitionController(IRecognitionService recognitionService) 
    { 
        _recognitionService = recognitionService;
    }

    [HttpGet("car-number")]
    public async Task<ActionResult<CarNumberDto>> GetCarNumberByImageAsync()//[FromBody] ImageDto image)
    {
        var image = new ImageDto();
        var retuls = await Task.Run(() => _recognitionService.GetCarNumberByImageAsync(image));

        return Ok(retuls);
    }
}
