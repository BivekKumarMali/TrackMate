using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class CommentContent : BaseModel
    {
        public int Position { get; set; }
        public ContentType ContentType { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Url { get; set; }

        public Comment Comment { get; set; }
    }
}
