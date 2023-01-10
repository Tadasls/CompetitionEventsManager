using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CompetitionEventsManager.Repository
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        private readonly DBContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

  
        public EntryRepository(DBContext db, IHttpContextAccessor httpContextAccessor) : base(db)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }


        //eager Loding

        //public void Getdata_With_EagerLoading()
        //{
        //    using var context = new DBContext();
        //    var entries = context.Entries
        //        .Include(b => b.Horses);
        //    foreach (var entry in entries)
        //    {
        //        Console.WriteLine($"** {entry.EntryID} {entry.PlateNumbers}");
        //        foreach (var horse in entry.Horses)
        //        {
        //            Console.WriteLine($"- {horse.HorseName} {horse.RiderID}");
        //        }
        //    }
        //}



        //public IEnumerable<Horse> Get(int riderId)
        //{
        //    var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);

        //    var entities =
        //        from entry in _db.Entries.Where(x => x.RiderID == riderId)
        //        join horse in _db.Horses on entry.HorseID equals horse.HorseID
        //        where entry.RiderID == riderId
        //        select horse;

      

        //    return entities;
        //}







    }
}
