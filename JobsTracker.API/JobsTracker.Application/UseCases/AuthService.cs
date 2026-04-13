using JobsTracker.Application.DTOs.AuthDTOs;
using JobsTracker.Application.Interfaces;
using JobsTracker.Domain.Entities;
using JobsTracker.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace JobsTracker.Application.UseCases
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<AuthService> _logger;  

        public AuthService(IUserRepository userRepository, IJwtProvider jwtProvider, IPasswordHasher passwordHasher, ILogger<AuthService> logger)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if(existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var passwordHash = _passwordHasher.Hash(dto.Password);

            var user = new User(dto.Email, passwordHash);

            _logger.LogInformation("New user registered with email: {Email}", dto.Email);

            await _userRepository.AddAsync(user);
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if(user == null || !_passwordHasher.Verify(dto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }

            _logger.LogInformation("User {Email} logged in successfully.", dto.Email);
            _logger.LogWarning("Failed login attempt for email {Email}.", dto.Email);

            return _jwtProvider.GenerateToken(user);
        }

    }
}
