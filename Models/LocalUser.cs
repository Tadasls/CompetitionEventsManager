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
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Display(Name = "Role")]
        public string Role { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "RegistrationDate")]
        public DateTime RegistrationDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "WasOnline")]
        public DateTime WasOnline { get; set; }
        [Display(Name = "Adress")]
        public string? Adress { get; set; }
        [Display(Name = "Phone")]
        public string? Phone { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Display(Name = "DefaultComunicationLanguage")]
        public string? DefaultComunicationLanguage { get; set; }
        [Display(Name = "Status")]
        public string? Status { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Rider> Riders { get; set; }
        public List<Horse> Horses { get; set; }
        public List<Entry> Reservations { get; set; }






    }
}
