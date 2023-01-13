namespace CompetitionEventsManager.Models.Dto.NotificationDTO
{
    public class CreateNotificationDTO
    {




        public int NotificationID { get; set; }
        public string Topic { get; set; }
        public string? Message { get; set; }
        public bool? Status { get; set; } = false;
        public int? UserId { get; set; }




    }
}