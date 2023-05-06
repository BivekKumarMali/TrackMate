using System.ComponentModel.DataAnnotations.Schema;
using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class Task: BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int AssignedUserId { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }


        [ForeignKey("Projectid")]
        public virtual Project Project { get; set; }
        [ForeignKey("AssignedUserId")]
        public virtual User AssignedUser { get; set; }

        public virtual ICollection<SubTask> SubTasks { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
