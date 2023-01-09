using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetitionEventsManager.Models
{
    public class Performance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PerformanceID { get; set; }
        public Horse Horse { get; set; }
        [Required]
        public int HorseID { get; set; }
        public Rider Rider { get; set; }
        [Required]
        public int RiderID { get; set; }
        public string? HorseName { get; set; }
        public string? RiderFullName { get; set; } 
        public DateTime? HorseBirthYear { get; set; }
        public int? Points { get; set; } = 0;
        public double? Time { get; set; } = 0.0;
        public bool? Training { get; set; } = false; 
        public string? Status { get; set; } 
        public string? Comments { get; set; } 





    }
}