using System;
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishesId {get; set;}

        [Required]
        [Display(Name = "Dish name")]
        public string Name {get; set;}

        [Required]
        [Display(Name = "Chef name")]
        public string Chef {get; set;}

        [Required]
        [Display(Name = "Tastiness")]
        public int Tastiness {get; set;}

        [Required(ErrorMessage = "The Calorie required")]
        [Display(Name = "Calorie")]
        [Range(1, 100000, ErrorMessage = "The Calorie should be at least 1")]
        public int Calorie {get; set;}

        [Display(Name = "Description: ")]
        public string Desc {get; set;}
        public DateTime CreateAt {get; set;} = DateTime.Now;
        public DateTime UpdateAt {get; set;} = DateTime.Now;
    }
}