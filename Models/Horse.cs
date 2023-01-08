using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileSystemGlobbing;
using System.Drawing;

namespace CompetitionEventsManager.Models
{
    public class Horse
    {
        public Horse()
        {

        }

        public Horse(int id, string horseName, string ownerName)
        {
            Id = id;
            HorseName = horseName;
            OwnerName = ownerName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string HorseName { get; set; }
        public string? OwnerName { get; set; }
        public DateTime? YearOfBird { get; set; }
        public string? Breed { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public string? Color { get; set; }
        public string? NatFedID { get; set; }
        public string? FEIID { get; set; }
        public int? Heigth { get; set; }
        public string? Father { get; set; }
        public string? Mother { get; set; }
        public string? Breeder { get; set; }
        public string? Commets { get; set; }
        public DateTime? MedCheckDate { get; set; }
        public string? PassportNo { get; set; }
        public DateTime? PassportNoExipreDate { get; set; }
        public int? ChipNumber { get; set; }
      





    }
}
