namespace CompetitionEventsManager.Services.IServices
{
    public interface INotificationService
    {
        Task MakeNotificationForUserWithRegistration(int? horseID, int? riderID, int userId);
    }
}