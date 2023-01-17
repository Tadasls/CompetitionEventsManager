namespace CompetitionEventsManager.Models.Dto.CompetitionDTO
{
    public class UpdateCompetitionDTO
    {

        public string? Title { get; set; }
        public string? Number { get; set; }
        /// <summary>
        /// opne
        /// </summary>
        public string? CompetitionType { get; set; }
        /// <summary>
        /// field or inside
        /// </summary>
        public string? ArenaType { get; set; }
        /// <summary>
        /// acording fei rules stated artickle
        /// </summary>
        public string? Article { get; set; }
        /// <summary>
        /// up to 2 rounds
        /// </summary>
        public int? Phase { get; set; } = 1;
        public DateTime? Date { get; set; }
        public DateTime? Time { get; set; }
        public string? Class { get; set; }
        public int? NumberOfJumps { get; set; }
        public int? NumberOfObstackles { get; set; }
        public int? TimeAllowed { get; set; }
        public int? SecToStart { get; set; }
        public int? PointsForExeedindTimeLimit { get; set; }
        public DateTime? SheduledStartTime { get; set; }
        public int? SheduledRunTime { get; set; }
        public int? TimeBeetweenRuns { get; set; }
        public int? BreakTime { get; set; }
        public int? AdditionalTime { get; set; }
      //  public int? SId { get; set; }
        public int? EId { get; set; }







    }
}