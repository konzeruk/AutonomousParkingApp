using AutonomousParkingApp.Authentication.Models.DTO;
using AutonomousParkingApp.Authentication.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AutonomousParkingApp.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) =>
            _authService = authService;

        [HttpPost("add-user")]
        public async Task<ActionResult> AddUserAsync([FromBody] UserForAuthDto user)
        {
            await _authService.AddUserAsync(user);

            return NoContent();
        }

        [HttpPut("update-user")]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserDto user)
        {
            await _authService.UpdateUserAsync(user);

            return NoContent();
        }

        [HttpGet("get-user/{userId}")]
        public async Task<ActionResult<UserDto>> GetUserByUserIdAsync([FromRoute] Guid userId)
        {
            var result = await _authService.GetUserByUserIdAsync(userId);

            return Ok(result);
        }

        [HttpGet("get-user-by-password/{password}")]
        public async Task<ActionResult<UserDto>> GetUserByPasswordAsync([FromRoute] string password)
        {
            var result = await _authService.GetUserByPasswordAsync(password);

            return Ok(result);
        }

        [HttpGet("get-userId-by-login/{login}")]
        public async Task<ActionResult<Guid>> GetUserIdByLoginAsync([FromRoute] string login)
        {
            var result = await _authService.GetUserIdByLoginAsync(login);

            return Ok(result);
        }
    }
}
