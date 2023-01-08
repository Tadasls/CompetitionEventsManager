using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        private readonly DBContext _db;

        public StaffRepository(DBContext db) : base(db)
        {
            _db = db;
        }



    }
}
