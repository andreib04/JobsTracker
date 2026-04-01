using JobsTracker.Domain.Entities;
using JobsTracker.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobsTracker.Infrastructure.Persistence.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _context;

        public NoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> GetByJobIdAsync(Guid jobId)
        {
            return await _context.Notes
                .Where(n => n.JobApplicationId == jobId)
                .ToListAsync();
        }

        public async Task AddAsync(Note note)
        {
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();
        }
    }
}
