using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TrackMate.Domain.Entities
{
    public class UserLogin : IdentityUserLogin<string>
    {
        [Key]
        public int Id { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
