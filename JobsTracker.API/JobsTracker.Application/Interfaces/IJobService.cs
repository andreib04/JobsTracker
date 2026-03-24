using JobsTracker.Application.DTOs.JobDTOs;

namespace JobsTracker.Application.Interfaces
{
    public interface IJobService
    {
        Task<List<JobDto>> GetUserJobsAsync(Guid userId);
        Task<Guid> CreateJobAsync(Guid userId, CreateJobDto dto);
        Task UpdateJobStatusAsync(Guid jobId, Guid userId, int status);
        Task DeleteJobAsync(Guid jobId, Guid userId);
    }
}
