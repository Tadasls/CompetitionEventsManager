using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetitionEventsManager.Models
{
    public class Rider
    {

        public Rider()
        {

        }
        public Rider(int riderID, string firstName, string lastName)
        {
            RiderID = riderID;
            FirstName = firstName;
            LastName = lastName;
        }

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
        public ICollection<LocalUser> LocalUsers { get; set; }
        public virtual ICollection<Horse> Horses { get; set; }


    }
}
