using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace CompetitionEventsManager.Models
{
    /// <summary>
    /// in Lithuania tai Yra Rungtis
    /// </summary>
    public class Competition
    {
        /// <summary>
        /// CompetitionID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompetitionID { get; set; }
        /// <summary>
        /// Competition titlew should be stated
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(10)]
        public string? Number { get; set; }
        [MaxLength(50)]
        public string? CompetitionType { get; set; }
        [MaxLength(50)]
        public string? ArenaType { get; set; }
        [MaxLength(10)]
        public string? Article { get; set; }
        [MaxLength(2)]
        public int? Phase { get; set; } = 1;
        [MaxLength(30)]
        public DateTime? Date { get; set; }
        [MaxLength(30)]
        public DateTime? Time { get; set; }
        [MaxLength(30)]
        public string? Class { get; set; }
        [MaxLength(3)]
        public int? NumberOfJumps { get; set; }
        [MaxLength(3)]
        public int? NumberOfObstackles { get; set; }
        [MaxLength(10)]
        public int? TimeAllowed { get; set; }
        [MaxLength(10)]
        public int? SecToStart { get; set; } = 45;
        [MaxLength(10)]
        public int? PointsForExeedindTimeLimit { get; set; } = 1;
        [MaxLength(20)]
        public DateTime? SheduledStartTime { get; set; }
        [MaxLength(20)]
        public int? SheduledRunTime { get; set; } = 2;
        [MaxLength(20)]
        public int? TimeBeetweenRuns { get; set; } = 10;
        [MaxLength(20)]
        public int? BreakTime { get; set; } = 10;
        [MaxLength(20)]
        public int? AdditionalTime { get; set; } = 10;
    
        [MaxLength(20)]
        public int? EId { get; set; }
        public virtual Event? Event { get; set; }
        public virtual List<Entry> Entries { get; set; }
        public virtual List<Staff> Staffs { get; set; }


        // public int? SId { get; set; }

    }
}
