﻿using System.ComponentModel.DataAnnotations.Schema;
using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class Comment: BaseModel
    {
        public int TaskId { get; set; }
        public int CommentUserId { get; set; }
        public int CommentableId { get; set; }
        public CommentableType CommentableType { get; set; }

        [ForeignKey("TaskId")]
        public virtual Task Task { get; set; }
        [ForeignKey("CommentUserId")]
        public virtual User CommentUserDetails { get; set; }


        public virtual ICollection<CommentContent> CommentContents { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
