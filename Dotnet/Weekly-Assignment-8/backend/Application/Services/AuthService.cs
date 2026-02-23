using Application.Interfaces;
using Backend.Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _repo;
        private readonly IJwtService _jwt;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthService(IUserRepository repo, IJwtService jwt)
        {
            _repo = repo;
            _jwt = jwt;
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
    }
}
