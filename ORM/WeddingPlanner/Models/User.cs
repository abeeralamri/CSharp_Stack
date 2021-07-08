using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        [Required]
        public string FName {get;set;}

        [Required]
        public string LName {get; set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}

        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;

        public List<Wedding> CreatedWedding {get;set;}
        public List<UserWedding> UserWedding {get;set;} 

    }
}