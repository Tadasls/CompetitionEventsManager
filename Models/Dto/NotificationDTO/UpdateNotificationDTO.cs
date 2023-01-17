namespace CompetitionEventsManager.Models.Dto.NotificationDTO
{
    public class UpdateNotificationDTO
    {


        public string? Topic { get; set; }
        /// <summary>
        /// should be some info here
        /// </summary>
        public string? Message { get; set; }
     
        public bool? Status { get; set; } = false;
        public int? UserId { get; set; }




    }
}