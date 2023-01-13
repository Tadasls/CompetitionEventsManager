using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.RiderDTO
{
    /// <summary>
    /// Get DTO
    /// </summary>
    public class GetRiderDTO
    {
        public GetRiderDTO(Rider rider)
        {
            RiderID = rider.RiderID;
            FirstName = rider.FirstName;
            LastName = rider.LastName;
            NationalFederationID = rider.NationalFederationID;
            FEIID = rider.FEIID;
            RidersClubName = rider.RidersClubName;
            DateOfBirth = rider.DateOfBirth;
            MedCheckDate = rider.MedCheckDate;
            InsuranceExiprationDate = rider.InsuranceExiprationDate;
            Country = rider.Country;
            Comments = rider.Comments;
            UserId = rider.UserId;
    }

 
        public int RiderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? NationalFederationID { get; set; }
        public int? FEIID { get; set; }
        public string? RidersClubName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? MedCheckDate { get; set; }
        public DateTime? InsuranceExiprationDate { get; set; }
        public string? Country { get; set; }
        public string? Comments { get; set; }

        public int? UserId { get; set; }




    }
}
