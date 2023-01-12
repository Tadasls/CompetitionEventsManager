namespace CompetitionEventsManager.Models.Dto.EventDTO
{
    public class FilterEventRequest
    {
        /// <summary>
        /// Search by Place name
        /// </summary>
        public string? Place { get; set; }
        /// <summary>
        /// Search by Country name
        /// </summary>
        public string? Country { get; set; }



    }
}