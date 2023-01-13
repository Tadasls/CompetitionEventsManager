namespace CompetitionEventsManager.Models.Dto.EventDTO
{
    public class CreateEventDTO
    {


        public string Title { get; set; }

        public string? Place { get; set; }

        public string? Country { get; set; }

        public string? Currency { get; set; }

        public string? Organizer { get; set; }

        public DateTime? Date { get; set; }
        public string? Type { get; set; }



    }
}