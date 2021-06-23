using Microsoft.AspNetCore.Mvc;
namespace Portfolio2.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("")]
        public  ViewResult Index(){

            return View();
            
        }
        
        [HttpGet("projects")]
        public  ViewResult Project(){

            return View();
            
        }
        [HttpGet("contact")]
        public  ViewResult Contact(){

            return View();
            
        }
    }
}