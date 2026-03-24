using JobsTracker.Domain.Entities;

namespace JobsTracker.Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<List<Note>> GetByJobIdAsync(Guid jobId);
        Task AddAsync(Note note);
    }
}
