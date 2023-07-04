using Microsoft.AspNetCore.Identity;
using TrackMate.Domain.Enums;
using TrackMate.Infrastructure.Data;

namespace TrackMate.Infrastructure
{
    public interface IDataSeeder
    {
        void SeedData();
    }
    public class DataSeeder : IDataSeeder
    {
        private readonly TrackMateDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeeder(TrackMateDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public void SeedData()
        {
            SeedDefaultRolesAsync();
        }

        #region Private Methods
        /// <summary>
        /// Seed all Role Enumns to Identity roles
        /// </summary>
        private async void SeedDefaultRolesAsync()
        {
            // Check if the roles already exist
            if (!_roleManager.Roles.Any())
            {
                var roles = new List<IdentityRole>();
                foreach (Role role in Enum.GetValues(typeof(Role)))
                {
                    roles.Add(new IdentityRole { Name = role.ToString() });
                }
                // Seed the roles into the database
                foreach (var role in roles)
                {
                    await _roleManager.CreateAsync(role);
                }
            }
        }
        #endregion
    }
}
