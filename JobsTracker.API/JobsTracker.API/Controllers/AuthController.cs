using JobsTracker.Application.Common;
using JobsTracker.Application.DTOs.AuthDTOs;
using JobsTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobsTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value!.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new
                {
                    success = false,
                    message = "Validation failed",
                    errors
                });
            }

            await _authService.RegisterAsync(dto);
            return Ok(ApiResponse<string>.SuccessResponse("", "User registered successfully"));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            return Ok(ApiResponse<string>.SuccessResponse(token, "Login successful"));
        }
    }
}
