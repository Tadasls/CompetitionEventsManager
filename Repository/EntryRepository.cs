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


        //public IEnumerable<Entry> Get(int userId)
        //{
        //    var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);

        //    //var id = _httpContextAccessor.HttpContext.Request.Query["personId"];


        //    var entities =
        //        from carUser in _db.CarUser.Where(x => x.LocalUserId == currentUserId)
        //            //from car in _context.Cars.Where(c => c.Id == carUser.CarId).DefaultIfEmpty() //left join
        //        join car in _db.Cars on carUser.CarId equals car.Id //inner join
        //        where carUser.LocalUserId == userId
        //        select car;



        //    return entities;
        //}


        //public IEnumerable<Performance> Get2(int entryID)
        //{
        //    // var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);

        //    //var id = _httpContextAccessor.HttpContext.Request.Query["personId"];


        //    var entities =
        //        from entry in _db.Entries.Where(x => x.EntryID == entryID)
        //        join performance in _db.Performances on entry.EntryID equals performance.PerformanceID 
        //        where entry.EntryID == entryID
        //        select performance;

        //    return entities;
        //}


        //public IEnumerable<Horse> GetHorseInfo(int horseID)
        //{
        //  //  var currentUserId = int.Parse(_httpContextAccessor.HttpContext.User.Identity.Name);


        //    var entities =
        //        from performance in _db.Performances.Where(x => x.HorseID == horseID)
        //        join horse in _db.Horses on performance.HorseID equals horse.HorseID 
        //        where performance.RiderID == horseID
        //        select horse;
        //    return entities;
        //}
















    }
}
