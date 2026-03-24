using JobsTracker.Application.DTOs;
using JobsTracker.Application.Interfaces;
using JobsTracker.Domain.Entities;
using JobsTracker.Domain.Interfaces;

namespace JobsTracker.Application.UseCases
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task AddNoteAsync(Guid jobId, CreateNoteDto dto)
        {
            var note = new Note(dto.Content, jobId);
            await _noteRepository.AddAsync(note);
        }

        public async Task<List<string>> GetNotesAsync(Guid jobId)
        {
            var notes = await _noteRepository.GetByJobIdAsync(jobId);   
            return notes.Select(n => n.Content).ToList();
        }
    }
}
