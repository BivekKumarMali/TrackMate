using TrackMate.Domain.Common;

namespace TrackMate.Domain.Entities
{
    public class SubTask : BaseTaskModel
    {
        public Task Task { get; set; }

        public virtual User? AssignedUser { get; set; }
        public SubTask? ParentSubTask { get; set; }
    }
}
