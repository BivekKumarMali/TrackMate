using System.Net.Mime;
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

        public int AttachableId { get; set; }
        public AttachableType AttachableType { get; set; }
    }
}
