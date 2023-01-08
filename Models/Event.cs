using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompetitionEventsManager.Models
{
    public class Event
    {
        [System.ComponentModel.DataAnnotations.Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventID { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Place { get; set; }
        public string? Country { get; set; }
        public string? Currency { get; set; }
        public string? Organizer { get; set; }
        public DateTime? Date { get; set; }
        public string? Type { get; set; }
       


    }
}
