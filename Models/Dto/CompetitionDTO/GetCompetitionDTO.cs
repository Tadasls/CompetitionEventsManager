using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.CompetitionDTO
{
    public class GetCompetitionDTO
    {
        public GetCompetitionDTO(Competition competition)
        {
            CompetitionID = competition.CompetitionID;
            Title = competition.Title;
            Number = competition.Number;
            CompetitionType = competition.CompetitionType;
            ArenaType = competition.ArenaType;
            Article = competition.Article;
            Phase = competition.Phase;
            Date = competition.Date;
            Time = competition.Time;
            Class = competition.Class;
            NumberOfJumps = competition.NumberOfJumps;
            NumberOfObstackles = competition.NumberOfObstackles;
            TimeAllowed = competition.TimeAllowed;
            SecToStart = competition.SecToStart;
            PointsForExeedindTimeLimit = competition.PointsForExeedindTimeLimit;
            SheduledStartTime = competition.SheduledStartTime;
            SheduledRunTime = competition.SheduledRunTime;
            TimeBeetweenRuns = competition.TimeBeetweenRuns;
            BreakTime = competition.BreakTime;
            AdditionalTime = competition.AdditionalTime;
        }

        public int CompetitionID { get; set; }
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