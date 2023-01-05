using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string OwnerName { get; set; }

        public DateTime BornDate { get; set; }

        //public Owner Owner{ get; set; }
        //public Raider Raider { get; set; }




    }
}
