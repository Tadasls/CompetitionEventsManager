using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.CompetitionDTO
{
    public class CreateCompetitionDTO
    {

        /// <summary>
        /// Title please be laconic
        /// </summary>
        [MaxLength(200)]
        public string Title { get; set; }
        /// <summary>
        /// Number
        /// </summary>
        public string? Number { get; set; }
        public string? CompetitionType { get; set; }
        public string? ArenaType { get; set; }
        public string? Article { get; set; }
        /// <summary>
        /// can be two , seconds means round 2
        /// </summary>
        public int? Phase { get; set; } = 1;
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public string? Class { get; set; }
        public int? NumberOfJumps { get; set; }
        public int? NumberOfObstackles { get; set; }
        public int? TimeAllowed { get; set; }
       /// <summary>
       /// usually 45 seks
       /// </summary>
        public int? SecToStart { get; set; }
        public int? PointsForExeedindTimeLimit { get; set; }
        public DateTime? SheduledStartTime { get; set; }
        public int? SheduledRunTime { get; set; }
        /// <summary>
        /// in secs
        /// </summary>
        public int? TimeBeetweenRuns { get; set; }
        public int? BreakTime { get; set; }
        public int? AdditionalTime { get; set; }
     //  public int? SId { get; set; }
        public int? EId { get; set; }





    }
}