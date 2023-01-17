using CompetitionEventsManager.Data;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CompetitionEventsManager.Repository
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        private readonly DBContext _db;
      

        public EntryRepository(DBContext db) : base(db)
        {
            _db = db;
           
        }



        public IEnumerable<Entry> GetSomeWithSQL(int userId)
        {
           
            var entities =
                from entry in _db.Entries.Where(x => x.UserId == userId)
                join horse in _db.Horses on entry.HorseID equals horse.HorseID
                join rider in _db.Riders on entry.RiderID equals rider.RiderID
                where entry.UserId == userId
                select entry;

            return entities; //grazina Horse objekta pagal entry esanty raiderio ID
        }
        public IEnumerable<Entry> Getdata_With_EagerLoading()
        {
           
            var duomenys = _db.Entries
            .Include(e => e.Horse)
            .Include(e => e.Rider)
            .ToList();

            return duomenys; //grazina visus entries su visais competisions
           
        }
        public IEnumerable<Event> Getdata_With_EagerLoading2()
        {
            var duomenys = _db.Events
            .Include(Event => Event.Competitions)
            .ToList();
            return duomenys; // grazina eventus su competitionais !!!
        }
 






    }
}
