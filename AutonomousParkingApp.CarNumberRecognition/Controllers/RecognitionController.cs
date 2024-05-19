using AutonomousParkingApp.CarNumberRecognition.Models;
using AutonomousParkingApp.CarNumberRecognition.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<CarNumberDto>> GetCarNumberByImageAsync() //[FromBody] ImageDto image)
    {

    }
}
