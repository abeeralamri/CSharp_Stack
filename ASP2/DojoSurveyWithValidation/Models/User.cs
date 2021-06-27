using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithValidation.Models
{
    public class User
    {
        [Required]
        [MinLength(2, ErrorMessage = "Your name should at least 2 character")]
        [Display(Name = "Name: ")]
        public string Name {get;set;}

        [Required]
        [Display(Name = "Location: ")]
        public string Loc {get;set;}

        [Required]
        [Display(Name = "Language: ")]
        public string Lang {get;set;}

        [MinLength(20, ErrorMessage = "Your comment should be at least 20 characters")]
        [Display(Name = "Comment: ")]
        
        public string Comment {get;set;}   
    }
}