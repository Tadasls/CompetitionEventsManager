using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CompetitionEventsManager.Repository
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        private readonly DBContext _db;

        public EntryRepository(DBContext db) : base(db)
        {
            _db = db;
        }




        //eager Loding

        public void Getdata_With_EagerLoading()
        {
            using var context = new DBContext();
            var performances = context.Performances
                .Include(b => b.Entries);
            foreach (var performance in performances)
            {
                Console.WriteLine($"** {performance.PerformanceID} {performance.Time}");
                foreach (var entry in performance.Entries)
                {
                    Console.WriteLine($"- {entry.EntryID} {entry.PlateNumbers}");
                }
            }
        }










    }
}
