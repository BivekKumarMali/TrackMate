using Microsoft.AspNetCore.Identity;

namespace TrackMate.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
