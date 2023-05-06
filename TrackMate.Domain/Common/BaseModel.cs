using System.ComponentModel.DataAnnotations.Schema;
using TrackMate.Domain.Entities;

namespace TrackMate.Domain.Common
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User CreatedBy { get; set; }
    }
}
