using JobsTracker.Domain.Common;
using JobsTracker.Domain.Enums;

namespace JobsTracker.Domain.Entities
{
    public class JobApplication : BaseEntity
    {
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public JobStatus Status { get; private set; }
        public DateTime AppliedDate { get; private set; }

        public decimal? SalaryMin { get; private set; }
        public decimal? SalaryMax { get; private set; }

        public string? JobUrl { get; private set; }

        public Guid UserId { get; private set; }
        public Guid CompanyId { get; private set; }

        private readonly List<Note> _notes = new();
        public IReadOnlyCollection<Note> Notes => _notes;

        private JobApplication() { }

        public JobApplication(
            string title,
            JobStatus status,
            DateTime appliedDate,
            Guid userId,
            Guid companyId,
            string? description = null,
            decimal? salaryMin = null,
            decimal? salaryMax = null,
            string? jobUrl = null)
        {
            Title = title;
            Status = status;
            AppliedDate = appliedDate;
            UserId = userId;
            CompanyId = companyId;
            Description = description;
            SalaryMin = salaryMin;
            SalaryMax = salaryMax;
            JobUrl = jobUrl;
        }

        public void UpdateStatus(JobStatus status)
        {
            Status = status;
            SetUpdated();
        }
    }
}
