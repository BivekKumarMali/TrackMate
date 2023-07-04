using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class Task : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }


        public Project Project { get; set; }
        public virtual User AssignedUser { get; set; }

        public ICollection<SubTask> SubTasks { get; } = new List<SubTask>();
        public ICollection<Attachment> Attachments { get; } = new List<Attachment>();
        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }

}
