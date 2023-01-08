using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto
{
    public class GetUserDto
    {
        
        public int Id { get; set; }
        /// <summary>
        /// Userio prtisijungimo vardas
        /// </summary>
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

    }
}

