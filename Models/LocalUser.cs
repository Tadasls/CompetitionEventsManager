using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models
{
    public class LocalUser
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime WasOnline { get; set; }
        public string UserLevel { get; set; }



                
               


    }
}
