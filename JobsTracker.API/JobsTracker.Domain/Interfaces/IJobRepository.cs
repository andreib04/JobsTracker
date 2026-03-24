using JobsTracker.Domain.Entities;

namespace JobsTracker.Domain.Interfaces
{
    public interface IJobRepository
    {
        Task<List<JobApplication>> GetByUserIdAsync(Guid userId);
        Task<JobApplication> GetByIdAsync(Guid id);
        Task AddAsync(JobApplication job);
        Task UpdateAsync(JobApplication job);
        Task DeleteAsync(JobApplication job);
    }
}
