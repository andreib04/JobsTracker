using JobsTracker.Application.DTOs;

namespace JobsTracker.Application.Interfaces
{
    public interface INoteService
    {
        Task AddNoteAsync(Guid jobId, CreateNoteDto dto);
        Task<List<string>> GetNotesAsync(Guid jobId);
    }
}
