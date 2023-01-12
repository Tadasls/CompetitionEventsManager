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
        }

        [MaxLength(50)]
        public int RiderID { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public int? NationalFederationID { get; set; }
        [MaxLength(50)]
        public int? FEIID { get; set; }
        [MaxLength(50)]
        public string? RidersClubName { get; set; }
        [MaxLength(50)]
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(50)]
        public DateTime? MedCheckDate { get; set; }
        [MaxLength(50)]
        public DateTime? InsuranceExiprationDate { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }
        [MaxLength(50)]
        public string? Comments { get; set; }
    
 




    }
}
