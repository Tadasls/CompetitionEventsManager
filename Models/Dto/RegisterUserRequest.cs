using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models.Dto
{
    public class RegisterUserRequest
    {
        [Required(ErrorMessage = "Reiksme yra labai labai svarbi")]
        [MaxLength(50, ErrorMessage = "Mark cannot be longer than 50 characters")]
        public string? UserName { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
         [MaxLength(50, ErrorMessage = "Role cannot be longer than 50 characters")]
        public string? Role { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Language { get; set; }
    }
}



