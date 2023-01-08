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
        public List<Performance> Performances { get; set; }
        public bool? NeedElectricity { get; set; }
        public string? PlateNumbers { get; set; }
        public int? numberOfCages { get; set; }
        public DateTime? StayFromDate { get; set; }
        public DateTime? StayToDate { get; set; }
        public bool? Shavings { get; set; }
        public bool? NeedInvoice { get; set; }
        public bool? AgreemntOnContractNr1 { get; set; }
        public string? Status { get; set; }






    }
}