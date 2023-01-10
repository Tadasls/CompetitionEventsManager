using CompetitionEventsManager.Models;

namespace CompetitionEventsManager.Repository.IRepository
{
    public interface IEntryRepository : IRepository<Entry>
    {
       
        IEnumerable<Entry> Getdata_With_EagerLoading(int riderId);
        IEnumerable<Horse> GetSome(int riderId);
    }
}