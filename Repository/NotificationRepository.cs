using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {

        private readonly DBContext _db;

        public NotificationRepository(DBContext db) : base(db)
        {
            _db = db;
        }


    }
}
