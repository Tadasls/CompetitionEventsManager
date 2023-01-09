namespace CompetitionEventsManager.Models.Dto.HorseDTO
{
    public class FilterHorsesRequest
    {
        /// <summary>
        /// paieska pagal Žirgo varda
        /// </summary>
        public string? HorseName { get; set; }
        public string? OwnerName { get; set; }
        public string? Breeder { get; set; }
        public string? Country { get; set; }




    }
}
