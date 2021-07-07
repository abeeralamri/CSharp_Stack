using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}

        [Required]
        [Display(Name = "Name")]
        public string Name {get; set;}

        [Required]
        [Display(Name = "Description")]
        public string Description {get; set;}

        [Required]
        [Display(Name = "The price")]
        public int price {get; set;}

        public List<Association> Associations {get; set;}

        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;
    }
}