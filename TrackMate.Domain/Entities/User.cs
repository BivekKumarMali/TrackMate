using TrackMate.Domain.Common;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class User: BaseModel
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
    }
}
