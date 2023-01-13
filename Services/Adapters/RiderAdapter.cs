using CompetitionEventsManager.Models.Dto.HorseDTO;
using CompetitionEventsManager.Models;
using CompetitionEventsManager.Models.Dto.RiderDTO;
using CompetitionEventsManager.Services.IServices;

namespace CompetitionEventsManager.Services.Adapters
{
    public class RiderAdapter: IRiderAdapter
    {
        public UpdateRiderDTO Bind(Rider rider)
        {
            return new UpdateRiderDTO
            {
                FirstName = rider.FirstName,
                LastName = rider.LastName,
                NationalFederationID = rider.NationalFederationID,
                FEIID = rider.FEIID,
                RidersClubName = rider.RidersClubName,
                MedCheckDate = rider.MedCheckDate,
                InsuranceExiprationDate = rider.InsuranceExiprationDate,
                Country = rider.Country,
                Comments = rider.Comments,
            };
        }

        public Rider Bind(UpdateRiderDTO updateRiderDTO, int id)
        {
            return new Rider
            {
                FirstName = updateRiderDTO.FirstName,
                LastName = updateRiderDTO.LastName,
                NationalFederationID = updateRiderDTO.NationalFederationID,
                FEIID = updateRiderDTO.FEIID,
                RidersClubName = updateRiderDTO.RidersClubName,
                MedCheckDate = updateRiderDTO.MedCheckDate,
                InsuranceExiprationDate = updateRiderDTO.InsuranceExiprationDate,
                Country = updateRiderDTO.Country,
                Comments = updateRiderDTO.Comments,
                RiderID = id
            };
        }



    









    }
}
