namespace CompetitionEventsManager.Models.Dto.UserDTO
{
    /// <summary>
    /// DTO for login
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// UserUserName
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// User Token
        /// </summary>
        public string? Token { get; set; }
    }
}