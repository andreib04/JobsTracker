
using JobsTracker.Application.DTOs.JobDTOs;
using JobsTracker.Application.Interfaces;
using JobsTracker.Domain.Entities;
using JobsTracker.Domain.Enums;
using JobsTracker.Domain.Interfaces;

namespace JobsTracker.Application.UseCases
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
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

            await _jobRepository.AddAsync(job);

            return job.Id;
        }

        public async Task UpdateJobStatusAsync(Guid jobId, Guid userId, int status)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);

            if(job == null || job.UserId != userId)
                throw new KeyNotFoundException("Job not found or access denied.");
        
            job.UpdateStatus((JobStatus)status);

            await _jobRepository.UpdateAsync(job);
        }

        public async Task DeleteJobAsync(Guid jobId, Guid userId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId);

            if(job == null || job.UserId != userId)
                throw new KeyNotFoundException("Job not found or access denied.");

            await _jobRepository.DeleteAsync(job);
        }
    }
}
