using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}

        [Required]
        [Display(Name = "First name")]
        public string FName {get; set;}

        [Required]
        [Display(Name = "Last name")]
        public string LName {get; set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth of date")]
        public DateTime BirthDate {get; set;}  
        public List<Dish> CreatedDish {get; set;} 
        public DateTime CreateAt {get; set;} = DateTime.Now;
        public DateTime UpdateAt {get; set;} = DateTime.Now; 
    }
}