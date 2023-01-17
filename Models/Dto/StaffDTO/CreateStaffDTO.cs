namespace CompetitionEventsManager.Models.Dto.StaffDTO
{
    /// <summary>
    /// to create new staff
    /// </summary>
    public class CreateStaffDTO
    {
   /// <summary>
   /// ame as Name
   /// </summary>
        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string? Country { get; set; }

        public string? FeiID { get; set; }

        public string? NationalID { get; set; }

        public string? Position { get; set; }

        public int? SId { get; set; }







    }
}