using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.EventDTO
{
    public class GetEventDTO
    {
        public GetEventDTO(Event eventx)
        {
            EventID = eventx.EventID;
            Title = eventx.Title;
            Place = eventx.Place;
            Country = eventx.Country;
            Currency = eventx.Currency;
            Organizer = eventx.Organizer;
            Date = eventx.Date;
            Type = eventx.Type;
        }

        public int EventID { get; set; }

        public string Title { get; set; }
      
        public string? Place { get; set; }
       
        public string? Country { get; set; } 
      /// <summary>
      /// thats euros , maybe zlots if it happens in Poland
      /// </summary>
        public string? Currency { get; set; }
       
        public string? Organizer { get; set; }
    
        public DateTime? Date { get; set; }
        public string? Type { get; set; }
    



    }
}