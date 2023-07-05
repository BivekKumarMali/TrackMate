using TrackMate.Domain.Common;

namespace TrackMate.Domain.Entities
{
    public class Project : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
