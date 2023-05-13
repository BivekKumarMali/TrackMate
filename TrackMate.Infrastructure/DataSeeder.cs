using TrackMate.Infrastructure.Data;

namespace TrackMate.Infrastructure
{
    public interface IDataSeeder
    {
        void SeedData();
    }
    public class DataSeeder: IDataSeeder
    {
        private readonly TrackMateDbContext _context;

        public DataSeeder(TrackMateDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {

        }
    }
}
