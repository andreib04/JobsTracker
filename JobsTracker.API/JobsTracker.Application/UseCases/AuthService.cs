using JobsTracker.Application.DTOs.AuthDTOs;
using JobsTracker.Application.Interfaces;
using JobsTracker.Domain.Entities;
using JobsTracker.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JobsTracker.Application.UseCases
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
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

            await _userRepository.AddAsync(user);
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if(user == null || !_passwordHasher.Verify(dto.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password.");
            }

            return _jwtProvider.GenerateToken(user);
        }

    }
}
