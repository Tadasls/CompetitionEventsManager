namespace CompetitionEventsManager.Models.Dto.HorseDTO
{
    /// <summary>
    /// Main items for filter
    /// </summary>
    public class FilterHorsesRequest
    {
        /// <summary>
        /// Search by Horse name
        /// </summary>
        public string? HorseName { get; set; }
        /// <summary>
        /// search by Owner name
        /// </summary>
        public string? OwnerName { get; set; }
        /// <summary>
        ///search by Breeder name
        /// </summary>
        public string? Breeder { get; set; }
        /// <summary>
        /// search by Country name
        /// </summary>
        public string? Country { get; set; }




    }
}
