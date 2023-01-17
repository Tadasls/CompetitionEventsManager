using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.HorseDTO
{
    /// <summary>
    /// DTO With Horse data
    /// </summary>
    public class CreateHorseDTO
    {
       /// <summary>
       /// animal name
       /// </summary>
        public string HorseName { get; set; }
        public string? OwnerName { get; set; }
        public DateTime? YearOfBird { get; set; }
        public string? Breed { get; set; }
        public string? Type { get; set; }
        /// <summary>
        /// exm stalion
        /// </summary>
        public string? Gender { get; set; }
        /// <summary>
        /// no white is not a color
        /// </summary>
        public string? Color { get; set; }
        public string? NatFedID { get; set; }
        public string? FEIID { get; set; }
        public int? Heigth { get; set; }
        public string? Father { get; set; }
        public string? Mother { get; set; }
        public string? Breeder { get; set; }
        public string? Country { get; set; }
        public string? Commets { get; set; }
        public DateTime? MedCheckDate { get; set; }
        public string? PassportNo { get; set; }
        public DateTime? PassportNoExipreDate { get; set; }
        public string? ChipNumber { get; set; }


    }
}