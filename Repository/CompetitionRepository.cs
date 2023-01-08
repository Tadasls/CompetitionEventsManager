using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    public class CompetitionRepository : Repository<Competition>, ICompetitionRepository
    {

        private readonly DBContext _db;

        public CompetitionRepository(DBContext db) : base(db)
        {
            _db = db;
        }




    }
}
