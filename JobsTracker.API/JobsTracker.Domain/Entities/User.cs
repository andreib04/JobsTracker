using JobsTracker.Domain.Common;

namespace JobsTracker.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }


        private readonly List<JobApplication> _jobApplications = new();
        public IReadOnlyCollection<JobApplication> JobApplications => _jobApplications;

        private User() { } //EF Core

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
