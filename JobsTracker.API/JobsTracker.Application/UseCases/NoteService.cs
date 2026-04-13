using JobsTracker.Application.DTOs;
using JobsTracker.Application.Interfaces;
using JobsTracker.Domain.Entities;
using JobsTracker.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace JobsTracker.Application.UseCases
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ILogger<NoteService> _logger;

        public NoteService(INoteRepository noteRepository, ILogger<NoteService> logger)
        {
            _noteRepository = noteRepository;
            _logger = logger;
        }

        public async Task AddNoteAsync(Guid jobId, CreateNoteDto dto)
        {
            var note = new Note(dto.Content, jobId);
            await _noteRepository.AddAsync(note);
            _logger.LogInformation("Note added to job {JobId}", jobId);
            _logger.LogWarning("Attempt to add note to non-existing job {JobId}", jobId);
        }

        public async Task<List<string>> GetNotesAsync(Guid jobId)
        {
            var notes = await _noteRepository.GetByJobIdAsync(jobId);   
            return notes.Select(n => n.Content).ToList();
        }
    }
}
