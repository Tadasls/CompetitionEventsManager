using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.EntryDTO
{
    public class GetEntryDTO
    {
        public GetEntryDTO(Entry entry)
        {
            EntryID = entry.EntryID;
            HorseID = entry.HorseID;
            RiderID = entry.RiderID;
            HorseName = entry.HorseName;
            RiderFullName = entry.RiderFullName;
            HorseBirthYear = entry.HorseBirthYear;
            Points = entry.Points;
            Time = entry.Time;
            Training = entry.Training;
            Status = entry.Status;
            Comments = entry.Comments;
            NeedElectricity = entry.NeedElectricity;
            PlateNumbers = entry.PlateNumbers;
            NumberOfCages = entry.NumberOfCages;
            StayFromDate = entry.StayFromDate;
            StayToDate = entry.StayToDate;
            Shavings = entry.Shavings;
            NeedInvoice = entry.NeedInvoice;
            AgreemntOnContractNr1 = entry.AgreemntOnContractNr1;
            UserId = entry.UserId;
            CId = entry.CId;

        }

        public int EntryID { get; set; }
     
        public int HorseID { get; set; }
        
        public int RiderID { get; set; }
   
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