using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto
{
    public class RegisterUserRequest
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Role { get; set; }

    }
}



