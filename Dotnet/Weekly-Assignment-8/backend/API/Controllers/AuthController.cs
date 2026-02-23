using Application.Services;
using Backend.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        try
        {
            var result = await _authService.Register(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            // Return proper error response
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        try
        {
            var result = await _authService.Login(dto);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

            return Unauthorized(new
            {
                message = ex.Message
            });
        }
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
    {
        await _authService.ForgotPassword(dto);
        return Ok("Password reset link sent");
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
    {
        await _authService.ResetPassword(dto);
        return Ok("Password reset successful");
    }
}