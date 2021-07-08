using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}

        [Required]
        public string Wedder1 {get;set;}

        [Required]
        public string Wedder2 {get;set;}

        [Required]
        public DateTime Date {get;set;}

        [Required]
        public string WeddingAddress {get;set;}

        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;

        public int UserId {get;set;}
        public User Creator {get;set;}
        public List<UserWedding> UserWedding {get;set;} 
    }
}