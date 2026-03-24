using JobsTracker.Domain.Entities;

namespace JobsTracker.Application.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
