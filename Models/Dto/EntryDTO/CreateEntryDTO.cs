using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.EntryDTO
{
    public class CreateEntryDTO
    {


        public int? HorseID { get; set; }
    
        public int? RiderID { get; set; }

        public string? HorseName { get; set; }
       
        public string? RiderFullName { get; set; }
     
        public DateTime? HorseBirthYear { get; set; }
        public int? Points { get; set; } = 0;
        public double? Time { get; set; } = 0.0;
 
        public bool? Training { get; set; } = false;

        public string? Status { get; set; }

        public string? Comments { get; set; }
      
        public bool? NeedElectricity { get; set; } = false;
  
        public string? PlateNumbers { get; set; }

        public int? NumberOfCages { get; set; } = 1;

        public DateTime? StayFromDate { get; set; }

        public DateTime? StayToDate { get; set; }
   
        public bool? Shavings { get; set; } = false;

        public bool? NeedInvoice { get; set; } = false;

        public bool? AgreemntOnContractNr1 { get; set; } = false;

        public int? UserId { get; set; }
        public int? CId { get; set; }
 






    }
}