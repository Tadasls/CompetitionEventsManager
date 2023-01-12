using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CompetitionEventsManager.Models
{
    /// <summary>
    /// Entry
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// Entry ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(20)]
        public int EntryID { get; set; }
        public Horse Horse { get; set; }
        [Required]
        [MaxLength(20)]
        public int HorseID { get; set; }
        public Rider Rider { get; set; }
        [Required]
        [MaxLength(20)]
        public int RiderID { get; set; }
        [MaxLength(100)]
        public string? HorseName { get; set; }
        [MaxLength(100)]
        public string? RiderFullName { get; set; }
        [MaxLength(50)]
        public DateTime? HorseBirthYear { get; set; }
        [MaxLength(50)]
        public int? Points { get; set; } = 0;
        [MaxLength(50)]
        public double? Time { get; set; } = 0.0;
        [MaxLength(50)]
        public bool? Training { get; set; } = false;
        [MaxLength(50)]
        public string? Status { get; set; }
        [MaxLength(50)]
        public string? Comments { get; set; }
        [MaxLength(50)]
        public bool? NeedElectricity { get; set; } = false;
        [MaxLength(50)]
        public string? PlateNumbers { get; set; }
        [MaxLength(50)]
        public int? NumberOfCages { get; set; } = 1;
        [MaxLength(50)]
        public DateTime? StayFromDate { get; set; }
        [MaxLength(50)]
        public DateTime? StayToDate { get; set; }
        [MaxLength(50)]
        public bool? Shavings { get; set; } = false;
        [MaxLength(50)]
        public bool? NeedInvoice { get; set; } = false;
        [MaxLength(50)]
        public bool? AgreemntOnContractNr1 { get; set; } = false;
       
        public int? UserId { get; set; }
        public virtual LocalUser? LocalUser { get; set; }
        public int? CId { get; set; }
        public virtual Competition? Competition { get; set; }


    }
}