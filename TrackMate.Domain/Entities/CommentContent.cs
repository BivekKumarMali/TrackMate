using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class CommentContent: BaseModel
    {
        public int Position { get; set; }
        public CommentContentType Type { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public ContentType ContentType{ get; set; }
        public int CommentId{ get; set; }
        public int CommentableTypeId{ get; set; }
        public CommentableType CommentableType { get; set; }

        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
    }
}
