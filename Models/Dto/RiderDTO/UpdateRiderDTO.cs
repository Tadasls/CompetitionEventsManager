using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.RiderDTO
{
    /// <summary>
    /// DTO
    /// </summary>
    public class UpdateRiderDTO
    {
      
        [MaxLength(100)]
        public string FirstName { get; set; }
       
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public int? NationalFederationID { get; set; }
        [MaxLength(50)]
        public int? FEIID { get; set; }
        [MaxLength(50)]
        public string? RidersClubName { get; set; }
        [MaxLength(50)]
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(50)]
        public DateTime? MedCheckDate { get; set; }
        [MaxLength(50)]
        public DateTime? InsuranceExiprationDate { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; } = "LT";
        [MaxLength(50)]
        public string? Comments { get; set; }





    }
}
