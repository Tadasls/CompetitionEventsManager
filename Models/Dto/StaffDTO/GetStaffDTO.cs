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
       
        }

        public int StaffID { get; set; }
    
        public string FirstName { get; set; }
     
        public string Lastname { get; set; }
      
        public string? Country { get; set; }
       /// <summary>
       /// identification number
       /// </summary>
        public string? FeiID { get; set; }
       
        public string? NationalID { get; set; }
      /// <summary>
      /// place and position at field
      /// </summary>
        public string? Position { get; set; }

    





    }
}