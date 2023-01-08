using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        private readonly DBContext _db;

        public EntryRepository(DBContext db) : base(db)
        {
            _db = db;
        }


    }
}
