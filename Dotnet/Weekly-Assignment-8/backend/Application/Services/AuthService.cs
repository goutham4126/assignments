using Application.Interfaces;
using Backend.Application.DTOs;
using Backend.Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _repo;
        private readonly IJwtService _jwt;
        private readonly PasswordHasher<User> _hasher = new();
        private readonly IEmailService _emailService;   

        public AuthService(IUserRepository repo, IJwtService jwt, IEmailService emailService)
        {
            _repo = repo;
            _jwt = jwt;
            _emailService = emailService;
        }

        public async Task<AuthResultDto> Register(RegisterDto dto)
        {
            if (await _repo.GetByUsernameAsync(dto.Username) != null)
                throw new Exception("Username already exists");

            var user = new User
            {
                Username = dto.Username,
                Role = dto.Role ?? "Customer"
            };

            user.PasswordHash = _hasher.HashPassword(user, dto.Password);
            await _repo.AddAsync(user);

            var token = _jwt.GenerateToken(user);

            return new AuthResultDto(token, user.Username, user.Role);
        }

        public async Task<AuthResultDto> Login(LoginDto dto)
        {
            var user = await _repo.GetByUsernameAsync(dto.Username);
            if (user == null) throw new Exception("Invalid credentials");

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid credentials");

            var token = _jwt.GenerateToken(user);

            return new AuthResultDto(token, user.Username, user.Role);
        }

        public async Task ForgotPassword(ForgotPasswordDto dto)
        {
                    var user = await _repo.GetByEmailAsync(dto.Email);

                    if (user == null)
                throw new Exception("User not found");

            var token = Guid.NewGuid().ToString();

            user.PasswordResetToken = token;
            user.PasswordResetTokenExpiry = DateTime.UtcNow.AddMinutes(30);

            await _repo.UpdateAsync(user);

            var resetLink = $"https://localhost:4200/reset-password?token={token}";

            await _emailService.SendEmailAsync(
                user.Email,
                "Password Reset",
                $"Click here to reset password: <a href='{resetLink}'>Reset</a>");
        }

public async Task ResetPassword(ResetPasswordDto dto)
{
    var users = await _repo.GetAllAsync();

    var targetUser = users.FirstOrDefault(u =>
        u.PasswordResetToken == dto.Token &&
        u.PasswordResetTokenExpiry > DateTime.UtcNow);

    if (targetUser == null)
        throw new Exception("Invalid or expired token");

    var hasher = new PasswordHasher<User>();

    targetUser.PasswordHash =
        hasher.HashPassword(targetUser, dto.NewPassword);

    targetUser.PasswordResetToken = null;
    targetUser.PasswordResetTokenExpiry = null;

    await _repo.UpdateAsync(targetUser);
}
    }
}
