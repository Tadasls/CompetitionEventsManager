using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetitionEventsManager.Models
{
    public class Event
    {

        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string? Place { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; } = "LT";
        [MaxLength(20)]
        public string? Currency { get; set; } = "Eur";
        [MaxLength(100)]
        public string? Organizer { get; set; }
        [MaxLength(50)]
        public DateTime? Date { get; set; }
        public string? Type { get; set; }
        public virtual List<Competition> Competitions { get; set; }

}
}
