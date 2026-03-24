using JobsTracker.Domain.Entities;

namespace JobsTracker.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(Guid id);
        Task AddAsync(Company company);
    }
}
