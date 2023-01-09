﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models
{
    public class LocalUser
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime WasOnline { get; set; }
        [Display(Name = "Adress")]
        public string? Adress { get; set; }
        [Display(Name = "Phone")]
        public string? Phone { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Display(Name = "Language")]
        public string? Language { get; set; }
        [Display(Name = "Status")]
        public string? Status { get; set; }
        public Notification Notification { get; set; }
        public Entry Entry { get; set; }
        public Rider Rider { get; set; }
        public Horse Horse { get; set; }



                
               


    }
}
