using JobsTracker.Domain.Common;

namespace JobsTracker.Domain.Entities
{
    public class Note : BaseEntity
    {
        public string Content { get; private set; }
        public Guid JobApplication { get; private set; }

        private Note() { }

        public Note(string content, Guid jobApplication)
        {
            Content = content;
            JobApplication = jobApplication;
        }
    }
}
