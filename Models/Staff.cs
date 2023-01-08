﻿using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CompetitionEventsManager.Models
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string Country { get; set; }
        public int FeiID { get; set; }
        public int NationalID { get; set; }
        public string Position { get; set; }



    }
}