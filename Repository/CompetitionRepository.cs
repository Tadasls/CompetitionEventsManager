using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;

namespace CompetitionEventsManager.Repository
{
    /// <summary>
/// works with competition database
/// </summary>
    public class CompetitionRepository : Repository<Competition>, ICompetitionRepository
    {

        private readonly DBContext _db;
        /// <summary>
        /// works with competition data crud
        /// </summary>
        /// <param name="db"></param>
        public CompetitionRepository(DBContext db) : base(db)
        {
            _db = db;
        }




    }
}
