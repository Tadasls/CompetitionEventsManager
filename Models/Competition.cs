using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetitionEventsManager.Models
{
    public class Competition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetitionID { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Number { get; set; }
        public string? CompetitionType { get; set; }
        public string? ArenaType { get; set; } 
        public string? Article { get; set; }
        public int? Phase { get; set; } = 1;
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public string? Class { get; set; }
        public int? NumberOfJumps { get; set; }
        public int? NumberOfObstackles { get; set; }
        public int? TimeAllowed { get; set; }
        public int? SecToStart { get; set; } = 45;
        public int? PointsForExeedindTimeLimit { get; set; } = 1;
        public DateTime? SheduledStartTime { get; set; }
        public int? SheduledRunTime { get; set; } = 2;
        public int? TimeBeetweenRuns { get; set; } = 10;
        public int? BreakTime { get; set; } = 10;
        public int? AdditionalTime { get; set; } = 10;
        public Performance Performance { get; set; }
        public Staff Staff { get; set; }
        public List<Event> Events { get; set; }

       





    }
}
