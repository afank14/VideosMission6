﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideosMission6.Models
{
    public class Application
    {
        [Key]
        [Required]
        public int ApplicationID { get; set; }
        [Required(ErrorMessage = "Sorry, you need to enter a first name")]
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        [Range(0, 100, ErrorMessage = "Must enter a valid age")]
        public int Age { get; set; } = 0;
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [ForeignKey("MajorId")]
        public int? MajorId {  get; set; }
        public Major? Major { get; set; }
        
        public bool CreeperStalker { get; set; }
    }
}
