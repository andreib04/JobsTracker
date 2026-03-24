using JobsTracker.Application.DTOs.AuthDTOs;

namespace JobsTracker.Application.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterUserDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }
}
