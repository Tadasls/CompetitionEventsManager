using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models
{
    /// <summary>
    /// Local User
    /// </summary>
    public class LocalUser
    {
        
        /// <summary>
        /// User ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        /// <summary>
        /// it your name
        /// </summary>
        [MaxLength(100)]
        public string FirstName { get; set; }
        /// <summary>
        /// family name
        /// </summary>
        [MaxLength(100)]
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime WasOnline { get; set; }
        [Display(Name = "Adress")]
        public string? Adress { get; set; }
        [Display(Name = "Phone")]
        [MaxLength(50)]
        public string? Phone { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Display(Name = "Language")]
        public string? Language { get; set; }
        [Display(Name = "Status")]
        public string? Status { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; } 
        public virtual ICollection<Entry> Entries { get; set; }
        public virtual ICollection<Rider> Riders { get; set; }
        public virtual ICollection<Horse> Horses { get; set; }



                
               


    }
}
