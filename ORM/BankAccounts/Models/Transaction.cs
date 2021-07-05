using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BankAccounts.Models
{
    public class Transaction
    {
        [Key]
        public int TransId {get; set;}

        public double Amount {get; set;}
        public DateTime CreatedAt = DateTime.Now;

        public int UserId {get; set;}
        public User UserAccount {get; set;}

    }
}