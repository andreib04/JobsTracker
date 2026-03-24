using JobsTracker.Domain.Enums;

namespace JobsTracker.Application.DTOs.JobDTOs
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public JobStatus Status { get; set; }
        public DateTime AppliedDate { get; set; }
        public string? CompanyName { get; set; }
    }
}
