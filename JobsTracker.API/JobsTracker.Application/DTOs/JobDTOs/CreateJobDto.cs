using JobsTracker.Domain.Enums;

namespace JobsTracker.Application.DTOs.JobDTOs
{
    public class CreateJobDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public JobStatus Status { get; set; }
        public DateTime AppliedDate { get; set; }
        public Guid CompanyId { get; set; }
        public decimal? SalaryMin { get; set; }
        public decimal? SalaryMax { get; set; }
        public string? JobUrl { get; set; }

    }
}
