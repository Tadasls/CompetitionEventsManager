using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

    }
}

