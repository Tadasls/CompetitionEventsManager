using CompetitionEventsManager.Models;

namespace CompetitionEventsManager.Repository.IRepository
{
    public interface IEntryRepository : IRepository<Entry>
    {
       
        IEnumerable<Entry> Getdata_With_EagerLoading();

        IEnumerable<Event> Getdata_With_EagerLoading2();

        IEnumerable<Entry> GetSomeWithSQL(int userId);

    }
}