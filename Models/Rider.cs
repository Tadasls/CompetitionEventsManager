using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection;

namespace CompetitionEventsManager.Models
{
    /// <summary>
    /// Rider
    /// </summary>
    public class Rider
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(50)]
        public int RiderID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public int? NationalFederationID { get; set; }
        [MaxLength(50)]
        public int? FEIID { get; set; }
        /// <summary>
        /// very important to be a part of team
        /// </summary>
        [MaxLength(50)]
        public string? RidersClubName { get; set; }
        [MaxLength(50)]
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(50)]
        public DateTime? MedCheckDate { get; set; }
        [MaxLength(50)]
        public DateTime? InsuranceExiprationDate { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; } = "LT";
        [MaxLength(50)]
        public string? Comments { get; set; }
        [MaxLength(50)]
        public int? UserId { get; set; }
        public virtual LocalUser? LocalUser { get; set; }
        public List<Entry> Entries { get; set; }



    }
}
