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
        [Display(Name = "Adress")]
        public string? Adress { get; set; }
        [Display(Name = "Phone")]
        public string? Phone { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Display(Name = "DefaultComunicationLanguage")]
        public string? Language { get; set; }
        [Display(Name = "Status")]
        public string? Status { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Rider> Riders { get; set; }
        public List<Horse> Horses { get; set; }
        public List<Entry> Reservations { get; set; }


                
               


    }
}
