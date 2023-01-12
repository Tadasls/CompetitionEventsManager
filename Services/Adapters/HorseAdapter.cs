using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.HorseDTO;
using Microsoft.Extensions.Hosting;
using System.Drawing;

namespace CompetitionEventsManager.Services.Adapters
{
    public class HorseAdapter  : IHorseAdapter
    {
        public UpdateHorseDTO Bind(Horse horse)
        {
            return new UpdateHorseDTO
            {
                Country = horse.Country,
                Gender = horse.Gender,
                OwnerName = horse.OwnerName,
                Breed = horse.Breed,
                Type = horse.Type,
                Color = horse.Color,
            };
        }

        public Horse Bind(UpdateHorseDTO updateHorseDTO, int id)
        {
            return new Horse
            {
                Country = updateHorseDTO.Country,
                Gender = updateHorseDTO.Gender,
                OwnerName = updateHorseDTO.OwnerName,
                Breed = updateHorseDTO.Breed,
                Type = updateHorseDTO.Type,
                Color = updateHorseDTO.Color,
                HorseID = id
            };
        }






    }
}
