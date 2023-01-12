using CompetitionEventsManager.Models;

namespace CompetitionEventsManager.Repository.IRepository
{
    public interface IEntryRepository : IRepository<Entry>
    {
       
        IEnumerable<Entry> Getdata_With_EagerLoading(int riderId);
        IEnumerable<Event> Getdata_With_EagerLoading2(int Id);
        IEnumerable<Entry> Getdata_With_EagerLoading3(int Id);
        IEnumerable<Horse> GetSomeWithSQL(int riderId);
    }
}