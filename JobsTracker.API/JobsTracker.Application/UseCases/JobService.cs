
using JobsTracker.Application.DTOs.JobDTOs;
using JobsTracker.Application.Interfaces;
using JobsTracker.Domain.Entities;
using JobsTracker.Domain.Enums;
using JobsTracker.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace JobsTracker.Application.UseCases
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ILogger<JobService> _logger;

        public JobService(IJobRepository jobRepository, ILogger<JobService> logger)
        {
            _jobRepository = jobRepository;
            _logger = logger;
        }

        public async Task<List<JobDto>> GetUserJobsAsync(Guid userId)
        {
            var jobs = await _jobRepository.GetByUserIdAsync(userId);

            return jobs.Select(j => new JobDto
            {
                Id = j.Id,
                Title = j.Title,
                Status = j.Status,
                AppliedDate = j.AppliedDate
            }).ToList();
        }

        public async Task<Guid> CreateJobAsync(Guid userId, CreateJobDto dto)
        {
            var job = new JobApplication(
                dto.Title,
                dto.Status,
                dto.AppliedDate,
                userId,
                dto.CompanyId,
                dto.Description,
                dto.SalaryMin,
                dto.SalaryMax,
                dto.JobUrl
            );

            _logger.LogInformation("User {UserId} created job {JobId}", userId, job.Id);

            await _jobRepository.AddAsync(job);

            return job.Id;

            
        }

        public async Task UpdateJobStatusAsync(Guid jobId, Guid userId, int status)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);

            if(job == null || job.UserId != userId)
            {
                _logger.LogWarning("Job {JobId} not found for user {UserId}", jobId, userId);
                throw new KeyNotFoundException("Job not found or access denied.");
            }
                
        
            job.UpdateStatus((JobStatus)status);

            _logger.LogInformation("User {UserId} updated job {JobId} status to {Status}", userId, jobId, status);

            await _jobRepository.UpdateAsync(job);
        }

        public async Task DeleteJobAsync(Guid jobId, Guid userId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);

            if(job == null || job.UserId != userId)
            {
                _logger.LogWarning("Job {JobId} not found for user {UserId}", jobId, userId);
                throw new KeyNotFoundException("Job not found or access denied."); 
            }

            _logger.LogWarning("User {UserId} deleted job {JobId}", userId, jobId);

            await _jobRepository.DeleteAsync(job);
        }
    }
}
