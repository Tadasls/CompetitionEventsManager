using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CompetitionEventsManager.Models
{
    public class Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntryID { get; set; }
        public bool? NeedElectricity { get; set; } = false;
        public string? PlateNumbers { get; set; }
        public int? NumberOfCages { get; set; } = 1;
        public DateTime? StayFromDate { get; set; }
        public DateTime? StayToDate { get; set; }
        public bool? Shavings { get; set; } = false; 
        public bool? NeedInvoice { get; set; } = false;
        public bool? AgreemntOnContractNr1 { get; set; } = false;
        public string? Status { get; set; }
        public Performance Performances { get; set; }
        public ICollection<LocalUser> LocalUsers { get; set; }




    }
}