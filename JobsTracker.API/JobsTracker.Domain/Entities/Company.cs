using JobsTracker.Domain.Common;

namespace JobsTracker.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }
        public string? Location { get; private set; }
        public string? Website { get; private set; }


        private readonly List<JobApplication> _jobApplications = new();
        public IReadOnlyCollection<JobApplication> JobApplications => _jobApplications;

        private Company() { }

        public Company(string name, string? location, string? website)
        {
            Name = name;
            Location = location;
            Website = website;
        }
    }
}
