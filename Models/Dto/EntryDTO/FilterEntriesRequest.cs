using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.EntryDTO
{
    public class FilterEntriesRequest
    {
        /// <summary>
        /// paieska pagal Entry 
        /// </summary>
        [MaxLength(100)]
        public int? EntryID { get; set; }
        /// <summary>
        /// paieska pagal Horse 
        /// </summary>
        [MaxLength(100)]
        public int? HorseID { get; set; }
        /// <summary>
        /// paieska pagal Rider 
        /// </summary>
        [MaxLength(100)]
        public int? RiderID { get; set; }

    }
}