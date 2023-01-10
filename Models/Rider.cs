using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection;

namespace CompetitionEventsManager.Models
{
    public class Rider
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RiderID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int? NationalFederationID { get; set; }
        public int? FEIID { get; set; }
        public string? RidersClubName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? MedCheckDate { get; set; }
        public DateTime? InsuranceExiprationDate { get; set; }
        public string? Country { get; set; } = "LT"; 
        public string? Comments { get; set; }

    

    }
}
