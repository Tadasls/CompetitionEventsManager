using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto.UserDTO
{
    public class GetUserDto
    {

        public int Id { get; set; }
        /// <summary>
        /// Userio prtisijungimo vardas
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Userio  vardas
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Userio  Pavarde
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Userio  Role
        /// </summary>
        public string Role { get; set; }

    }
}

