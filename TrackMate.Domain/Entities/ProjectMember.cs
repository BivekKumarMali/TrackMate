using System.ComponentModel.DataAnnotations.Schema;
using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class ProjectMember: BaseModel
    {
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        [ForeignKey("MemberId")]
        public virtual User Member { get; set; }

    }
}
