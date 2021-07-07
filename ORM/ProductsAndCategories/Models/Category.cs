using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get; set;}

        [Required]
        [Display(Name = "Name")]
        public string Name {get; set;}

        public List<Association> Associations {get; set;}
        
        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;

    }
}