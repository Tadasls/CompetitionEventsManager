using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.StaffDTO
{
    public class GetStaffDTO
    {
        public GetStaffDTO(Staff staff)
        {
            StaffID = staff.StaffID;
            FirstName = staff.FirstName;
            Lastname = staff.Lastname;
            Country = staff.Country;
            FeiID = staff.FeiID;
            NationalID = staff.NationalID;
            Position = staff.Position;
           // SId = staff.SId;
        }

        public int StaffID { get; set; }
    
        public string FirstName { get; set; }
     
        public string Lastname { get; set; }
      
        public string? Country { get; set; }
       
        public string? FeiID { get; set; }
       
        public string? NationalID { get; set; }
      
        public string? Position { get; set; }

      //  public int? SId { get; set; }





    }
}