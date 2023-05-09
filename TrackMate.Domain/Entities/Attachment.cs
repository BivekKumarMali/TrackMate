using System.ComponentModel.DataAnnotations.Schema;
using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class Attachment : BaseModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public ContentType ContentType { get; set; }
        public int FileSize { get; set; }

        public int? TaskId { get; set; }
        public int? SubTaskId { get; set; }
        public int? CommentId { get; set; }
        [ForeignKey("TaskId")]
        public virtual Task Task { get; set; }
        [ForeignKey("SubTaskId")]
        public virtual SubTask SubTask { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }

    }
}
