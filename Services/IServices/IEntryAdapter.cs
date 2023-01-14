using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.EntryDTO;

namespace CompetitionEventsManager.Services.IServices
{
    public interface IEntryAdapter
    {
        UpdateEntryDTO Bind(Entry entry);
        Entry Bind(UpdateEntryDTO updateEntryDTO, int id);
    }
}