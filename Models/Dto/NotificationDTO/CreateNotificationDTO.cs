namespace CompetitionEventsManager.Models.Dto.NotificationDTO
{
    public class CreateNotificationDTO
    {



        /// <summary>
        /// thats auto generated
        /// </summary>
        public int NotificationID { get; set; }
        /// <summary>
        /// main info
        /// </summary>
        public string Topic { get; set; }
        public string? Message { get; set; }
        public bool? Status { get; set; } = false;
        public int? UserId { get; set; }




    }
}