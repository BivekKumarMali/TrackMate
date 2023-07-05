using TrackMate.Domain.Entities;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Common
{
    public class BaseTaskModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; }
        public Priority? Priority { get; set; }
        public DateTime? DueDate { get; set; }


        public ICollection<Attachment> Attachments { get; } = new List<Attachment>();
        public ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
