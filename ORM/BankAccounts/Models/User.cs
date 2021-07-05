using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts.Models
{
    public class User
    {
        [Key]
        public int UserId {get; set;}

        [Required]
        public string FName {get; set;}
        
        [Required]
        public string LName {get; set;}

        [Required]
        [EmailAddress]
        public string Email {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}

        public double Balance {get; set;} = 0;
        public List<Transaction> Transactions {get; set;}

        [NotMapped]
        [Compare("Password", ErrorMessage = "Passwords does not match!")]
        [DataType(DataType.Password)]
        public string Confirm {get; set;}
        
        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;




    }
}