using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models
{
    /// <summary>
    /// Staff
    /// </summary>
    public class Staff
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; } = "LT";
        /// <summary>
        /// just a number
        /// </summary>
        [MaxLength(50)]
        public string? FeiID { get; set; }
        [MaxLength(50)]
        public string? NationalID { get; set; }
        [MaxLength(50)]
        public string? Position { get; set; }
        public virtual List<Competition> Competitions { get; set; }
    }
}
