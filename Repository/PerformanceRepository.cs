using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    public class PerformanceRepository : Repository<Performance>, IPerformanceRepository
    {
        private readonly DBContext _db;

        public PerformanceRepository(DBContext db) : base(db)
        {
            _db = db;
        }


    }
}
