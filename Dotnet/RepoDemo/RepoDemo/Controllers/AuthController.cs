using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepoDemo.DTOs;
using RepoDemo.Services;

namespace RepoDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto.Username, dto.Password);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto.Username, dto.Password);
            return Ok(new { Token = token });
        }

        [HttpGet("secure")]
        [Authorize]
        public IActionResult SecureEndpoint()
        {
            return Ok("You accessed protected endpoint!");
        }
    }
}
