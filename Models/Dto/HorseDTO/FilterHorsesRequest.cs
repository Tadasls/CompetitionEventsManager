namespace CompetitionEventsManager.Models.Dto.HorseDTO
{
    public class FilterHorsesRequest
    {
        /// <summary>
        /// paieska pagal Žirgo varda
        /// </summary>
        public string? HorseName { get; set; }
        /// <summary>
        /// paieska pagal Žirgo savininko vardą
        /// </summary>
        public string? OwnerName { get; set; }
        /// <summary>
        /// paieska pagal Žirgo veisėją
        /// </summary>
        public string? Breeder { get; set; }
        /// <summary>
        /// paieska pagal Žirgo kilmės šalį
        /// </summary>
        public string? Country { get; set; }




    }
}
