using JobsTracker.Application.Common;
using JobsTracker.Application.DTOs.JobDTOs;
using JobsTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobsTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        private Guid GetUserId() => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var userId = GetUserId();
            var jobs = await _jobService.GetUserJobsAsync(userId);
            return Ok(ApiResponse<IEnumerable<JobDto>>.SuccessResponse(jobs));
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob(CreateJobDto dto)
        {
            var userId = GetUserId();
            var jobId = await _jobService.CreateJobAsync(userId, dto);
            return Ok(ApiResponse<Guid>.SuccessResponse(jobId, "Job created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] int status)
        {
            var userId = GetUserId();
            await _jobService.UpdateJobStatusAsync(id, userId, status);
            return Ok(ApiResponse<string>.SuccessResponse("", "Job status updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(Guid id)
        {
            var userId = GetUserId();
            await _jobService.DeleteJobAsync(id, userId);
            return Ok(ApiResponse<string>.SuccessResponse("", "Job deleted successfully"));
        }
    }
}
