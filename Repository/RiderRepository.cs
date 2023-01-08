using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    public class RiderRepository : Repository<Rider>, IRiderRepository
    {

        private readonly DBContext _db;

        public RiderRepository(DBContext db) : base(db)
        {
            _db = db;
        }

    }
}
