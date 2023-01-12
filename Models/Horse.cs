using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models
{
    /// <summary>
    /// Horse Model
    /// </summary>
    public class Horse
    {
        /// <summary>
        /// Horse ID
        /// </summary>     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HorseID { get; set; }
        /// <summary>
        /// Horse Name
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string HorseName { get; set; }
        [MaxLength(50)]
        public string? OwnerName { get; set; }
        [MaxLength(50)]
        public DateTime? YearOfBird { get; set; }
        [MaxLength(50)]
        public string? Breed { get; set; }
        [MaxLength(50)]
        public string? Type { get; set; }
        [MaxLength(50)]
        public string? Gender { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }
        [MaxLength(50)]
        public string? NatFedID { get; set; }
        [MaxLength(50)]
        public string? FEIID { get; set; }
        [MaxLength(50)]
        public int? Heigth { get; set; }
        [MaxLength(50)]
        public string? Father { get; set; }
        [MaxLength(50)]
        public string? Mother { get; set; }
        [MaxLength(50)]
        public string? Breeder { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }
        [MaxLength(50)]
        public string? Commets { get; set; }
        [MaxLength(100)]
        public DateTime? MedCheckDate { get; set; }
        [MaxLength(50)]
        public string? PassportNo { get; set; }
        [MaxLength(50)]
        public DateTime? PassportNoExipreDate { get; set; }
        [MaxLength(50)]
        public string? ChipNumber { get; set; }
        public int? UserId { get; set; }
        public virtual LocalUser? LocalUser { get; set; }


    }
}
