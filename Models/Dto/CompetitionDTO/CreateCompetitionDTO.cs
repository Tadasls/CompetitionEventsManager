﻿namespace CompetitionEventsManager.Models.Dto.CompetitionDTO
{
    public class CreateCompetitionDTO
    {

   
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
        public int? SecToStart { get; set; }
        public int? PointsForExeedindTimeLimit { get; set; }
        public DateTime? SheduledStartTime { get; set; }
        public int? SheduledRunTime { get; set; }
        public int? TimeBeetweenRuns { get; set; }
        public int? BreakTime { get; set; }
        public int? AdditionalTime { get; set; }







    }
}