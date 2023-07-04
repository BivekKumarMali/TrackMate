using TrackMate.Domain.Common;

namespace TrackMate.Domain.Entities
{
    public class Comment : BaseModel
    {
        public Task? Task { get; set; }
        public SubTask? SubTask { get; set; }
        public virtual User CommentUserDetails { get; set; }


        public virtual ICollection<CommentContent> CommentContents { get; } = new List<CommentContent>();
        public virtual ICollection<Attachment> Attachments { get; } = new List<Attachment>();
    }
}
