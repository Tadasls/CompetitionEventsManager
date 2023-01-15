using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.EntryDTO;

namespace CompetitionEventsManager.Services.Adapters.IAdapters
{
    public interface IEntryAdapter
    {
        UpdateEntryDTO Bind(Entry entry);
        Entry Bind(UpdateEntryDTO updateEntryDTO, int id);
    }
}