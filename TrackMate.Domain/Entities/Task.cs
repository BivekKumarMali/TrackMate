using System.ComponentModel.DataAnnotations.Schema;
using TrackMate.Domain.Common;

namespace TrackMate.Domain.Entities
{
    public class Task : BaseTaskModel
    {
        public Project Project { get; set; }

        [InverseProperty("Tasks")]
        public virtual User? AssignedUser { get; set; }
        public ICollection<SubTask> SubTasks { get; } = new List<SubTask>();
    }

}
