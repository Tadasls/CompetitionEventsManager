using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection;

namespace CompetitionEventsManager.Models.Dto.RiderDTO
{
    /// <summary>
    /// need data to enter new rider
    /// </summary>
      public class CreateRiderDTO
    {

       /// <summary>
       /// it a name
       /// </summary>
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
