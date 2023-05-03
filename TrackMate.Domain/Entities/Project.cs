using TrackMate.Domain.Common;

namespace TrackMate.Domain.Entities
{
    public class Project: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
