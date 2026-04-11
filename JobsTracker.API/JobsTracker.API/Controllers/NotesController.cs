using JobsTracker.Application.DTOs;
using JobsTracker.Application.Interfaces;
using JobsTracker.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace JobsTracker.API.Controllers
{
    [ApiController]
    [Route("api/jobs/{jobId}/notes")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes(Guid jobId)
        {
            var notes = await _noteService.GetNotesAsync(jobId);
            return Ok(notes);
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(Guid jobId, CreateNoteDto dto)
        {
            await _noteService.AddNoteAsync(jobId, dto);
            return Ok();
        }
    }
}
