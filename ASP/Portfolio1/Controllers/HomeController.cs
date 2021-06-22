using Microsoft.AspNetCore.Mvc;
namespace Portfolio1.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]        
        [HttpGet]

        public string index(){
            return "This is my Index!";
        }

        [HttpGet]
        [Route("projects")]
        public string Project()
        {
            return $"This is my projects!";
        }
        [HttpGet]
        [Route("contact")]
        public string Contact()
        {
            return $"This is my Contact!";
        }
    }
}