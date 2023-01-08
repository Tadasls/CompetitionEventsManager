using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {

        private readonly DBContext _db;

        public EventRepository(DBContext db) : base(db)
        {
            _db = db;
        }

    }
}
