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

        //public void GetBlogs_EagerLoading()
        //{
        //    using var context = new DBContext();
        //    var entries = context.Entries
        //        .Include(b => b.Performances); 
        //    foreach (var entry in entries)
        //    {
        //        Console.WriteLine($"** {entry.EntryID} {entry.PlateNumbers}");
        //        foreach (var performance in entry.Performances)
        //        {
        //            Console.WriteLine($"- {performance.RiderID} {performance.HorseName}");
        //        }
        //    }
        //}













    }
}
