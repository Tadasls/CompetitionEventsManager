using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.RiderDTO
{
    /// <summary>
    /// Filter DTO
    /// </summary>
    public class FilterRidersRequest
    {

        /// <summary>
        /// paieska pagal Raitelio varda 
        /// </summary>
        [MaxLength(100)]
        public string? FirstName { get; set; }
        /// <summary>
        /// paieska pagal Raitelio Pavarde 
        /// </summary>
        [MaxLength(100)]
        public string? LastName { get; set; }
        /// <summary>
        ///  paieska pagal Raitelio kluba 
        /// </summary>
        [MaxLength(100)]
        public string? RidersClubName { get; set; }
        /// <summary>
        /// paieska pagal Raitelio kilmės šalį
        /// </summary>
        [MaxLength(50)]
        public string? Country { get; set; }
     




    }
}
