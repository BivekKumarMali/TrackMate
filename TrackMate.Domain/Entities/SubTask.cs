using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class SubTask : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }


        public Task Task { get; set; }
        public virtual User AssignedUser { get; set; }
        public SubTask? ParentSubTask { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
