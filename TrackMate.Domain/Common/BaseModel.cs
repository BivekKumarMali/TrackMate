using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackMate.Domain.Entities;

namespace TrackMate.Domain.Common
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User CreatedBy { get; set; }
    }
}
