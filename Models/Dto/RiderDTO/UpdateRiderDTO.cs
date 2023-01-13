using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.RiderDTO
{
    /// <summary>
    /// DTO
    /// </summary>
    public class UpdateRiderDTO
    {
      

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
