using JobsTracker.Domain.Common;

namespace JobsTracker.Domain.Entities
{
    public class Note : BaseEntity
    {
        public string Content { get; private set; }
        public Guid JobApplicationId { get; private set; }

        private Note() { }

        public Note(string content, Guid jobApplicationId)
        {
            Content = content;
            JobApplicationId = jobApplicationId;
        }
    }
}
