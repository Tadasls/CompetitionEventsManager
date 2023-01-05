namespace CompetitionEventsManager.Services.IServices
{
    public interface IJwtService
    {
        //  string GetJwtToken(int userId, string role);

        string GetJwtToken(int userId, string role, string userLevel);
    }
}