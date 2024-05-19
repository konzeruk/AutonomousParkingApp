using AutonomousParkingApp.StorageCarNumbers.Models.DTO;
using AutonomousParkingApp.StorageCarNumbers.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutonomousParkingApp.StorageCarNumbers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageCarNumbersService _storageCarNumbersService;

        public StorageController(IStorageCarNumbersService storageCarNumbersService) 
        { 
            _storageCarNumbersService = storageCarNumbersService;
        }

        [HttpGet("all-parking")]
        public async Task<ActionResult<ICollection<ParkingDto>>> GetAllParkingAsync()
        {
            var result = await _storageCarNumbersService.GetAllParkingAsync();

            return Ok(result);
        }

        [HttpGet("price/{userId}")] 
        public async Task<ActionResult<PriceDto>> GetPriceByUserIdAsync(Guid userId)
        {
            var result = await _storageCarNumbersService.GetPriceByUserIdAsync(userId);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddReservationAsync([FromBody] ReservationDto reservation)
        {
            await _storageCarNumbersService.AddReservationAsync(reservation);

            return NoContent();
        }

        [HttpDelete("delete/{userId}")]
        public async Task<ActionResult> DeleteReservationAsync(Guid userId)
        {
            await _storageCarNumbersService.DeleteReservationAsync(userId);

            return NoContent();
        }
    }
}
