using System.ComponentModel.DataAnnotations.Schema;
using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class SubTask: BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public int AssignedUserId { get; set; }
        public int? ParentSubTaskId { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public DateTime DueDate { get; set; }


        [ForeignKey("TaskId")]
        public virtual Task Task { get; set; }
        [ForeignKey("AssignedUserId")]
        public virtual User AssignedUser { get; set; }
        [ForeignKey("ParentSubTaskId")]
        public virtual SubTask ParentSubTask { get; set; }

        public virtual ICollection<Comment> Comments { get; set;}
        public virtual ICollection<Attachment> Attachments { get; set;}
    }
}
