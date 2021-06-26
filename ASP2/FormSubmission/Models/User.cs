using System.ComponentModel.DataAnnotations;

namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage = "The First Name Should be at least 4")]
        public string firstName {get; set;}

        [Required]
        [MinLength(4, ErrorMessage = "The Last Name Should be at least 4") ]
        public string lastName {get; set;}

        [Required]
        [Range(0,120, ErrorMessage = "The age Should be positive")]
        [Display(Name = "Your Age:")]
        public string Age {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Your email:")]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Your Password:")]
        public string Password {get; set;}
    }
}