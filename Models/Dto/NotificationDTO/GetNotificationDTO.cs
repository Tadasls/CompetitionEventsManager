using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.NotificationDTO
{
    public class GetNotificationDTO
    {
        public GetNotificationDTO(Notification notification)
        {
            NotificationID = notification.NotificationID;
            Topic = notification.Topic;
            Message = notification.Message;
            Status = notification.Status;
            UserId = notification.UserId;
        }

        public int NotificationID { get; set; }
     
        public string Topic { get; set; }
    
        public string? Message { get; set; }
    
        public bool? Status { get; set; } = false;
        public int? UserId { get; set; }

    }
}