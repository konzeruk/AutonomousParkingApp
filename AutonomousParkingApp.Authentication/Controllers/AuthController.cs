using AutonomousParkingApp.Authentication.Exceptions;
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
        public async Task<ActionResult> AddUserAsync([FromBody] RegDto user)
        {
            try
            {
                await _authService.AddUserAsync(user);

                return NoContent();
            }
            catch (AuthException ex)
            {
                return Problem(ex.Message, statusCode: ex.StatusCode);
            }
        }

        [HttpPut("update-user")]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UserDto user)
        {
            try
            {
                await _authService.UpdateUserAsync(user);

                return NoContent();
            }
            catch (AuthException ex)
            {
                return Problem(ex.Message, statusCode: ex.StatusCode);
            }
        }

        [HttpGet("get-user/{userId}")]
        public async Task<ActionResult<UserDto>> GetUserByUserIdAsync([FromRoute] Guid userId)
        {
            try
            {
                var result = await _authService.GetUserByUserIdAsync(userId);

                return Ok(result);
            }
            catch (AuthException ex)
            {
                return Problem(ex.Message, statusCode: ex.StatusCode);
            }
        }

        [HttpPost("get-user-by-login-password")]
        public async Task<ActionResult<UserDto>> GetUserAsync([FromBody] AuthDto authDto)
        {
            try
            {
                var result = await _authService.GetUserAsync(authDto);

                return Ok(result);
            }
            catch (AuthException ex)
            {
                return Problem(ex.Message, statusCode: ex.StatusCode);
            }
        }

        [HttpGet("get-userId-by-login/{login}")]
        public async Task<ActionResult<Guid>> GetUserIdByLoginAsync([FromRoute] string login)
        {
            try
            {
                var result = await _authService.GetUserIdByLoginAsync(login);

                return Ok(result);
            }
            catch (AuthException ex)
            {
                return Problem(ex.Message, statusCode: ex.StatusCode);
            }
        }
    }
}
