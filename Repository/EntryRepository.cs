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







        public IEnumerable<Horse> GetSomeWithSQL(int riderId)
        {
           
            var entities =
                from entry in _db.Entries.Where(x => x.RiderID == riderId)
                join horse in _db.Horses on entry.HorseID equals horse.HorseID
                where entry.RiderID == riderId
                select horse;

            return entities; //grazina Horse objekta pagal entry esanty raiderio ID
        }
        public IEnumerable<Entry> Getdata_With_EagerLoading(int riderId)
        {
           
            var duomenys = _db.Entries
            .Include(Entries => Entries.Competition)
            // .Include(blog => blog.LocalUser)
            .ToList();

            return duomenys; //grazina visus entries su visais competisions
           
        }
        public IEnumerable<Event> Getdata_With_EagerLoading2(int Id)
        {
            var duomenys = _db.Events
            .Include(Event => Event.Competitions)
            .ToList();
            return duomenys; // grazina eventus su competitionais !!!
        }
        public IEnumerable<Entry> Getdata_With_EagerLoading3(int Id)
        {
            var duomenys = _db.Entries
            .Include(ab => ab.Competition)
            .ToList();
            return duomenys; // grazina entries su competitionais !!!
        }







    }
}
