using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.HorseDTO;

namespace CompetitionEventsManager.Services.IServices
{
    public interface IHorseAdapter
    {
        UpdateHorseDTO Bind(Horse horse);
        Horse Bind(UpdateHorseDTO updateHorseDTO, int id);
    }
}