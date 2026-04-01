using JobsTracker.Domain.Entities;
using JobsTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace JobsTracker.Infrastructure.Persistence.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _context;
    
        public JobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobApplication>> GetByUserIdAsync(Guid userId)
        {
            return await _context.JobApplications
                .Where(j => j.UserId == userId)
                .ToListAsync();
        }

        public async Task<JobApplication?> GetByIdAsync(Guid id)
        {
            return await _context.JobApplications.FindAsync(id);
        }

        public async Task AddAsync(JobApplication job)
        {
            await _context.JobApplications.AddAsync(job);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(JobApplication job)
        {
            _context.JobApplications.Update(job);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(JobApplication job)
        {
            _context.JobApplications.Remove(job);
            await _context.SaveChangesAsync();
        }
    }
}
