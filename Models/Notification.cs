using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace CompetitionEventsManager.Models
{
    /// <summary>
    /// Notification
    /// </summary>
    public class Notification
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Topic { get; set; }
        [MaxLength(300)]
        public string? Message { get; set; }
        [MaxLength(50)]
        public bool? Status { get; set; } = false;
        public int? UserId { get; set; }
        public virtual LocalUser? LocalUser { get; set; }  


    }
}