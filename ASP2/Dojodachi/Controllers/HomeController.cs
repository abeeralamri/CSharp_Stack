using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet("")]
        public ViewResult Index()
       {
           
          if(HttpContext.Session.GetInt32("Happy") == null || HttpContext.Session.GetInt32("Energy") == null || HttpContext.Session.GetInt32("Meal") == null || HttpContext.Session.GetInt32("Fullness") == null){
              HttpContext.Session.SetInt32("Happy", 50);
              HttpContext.Session.SetInt32("Energy", 0);
              HttpContext.Session.SetInt32("Meal", 3);
              HttpContext.Session.SetInt32("Fullness", 20);
          }
           
           ViewBag.Happy = HttpContext.Session.GetInt32("Happy");
           ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
           ViewBag.Meal = HttpContext.Session.GetInt32("Meal");
           ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");

           if(HttpContext.Session.GetInt32("Fullness") <= 0 || HttpContext.Session.GetInt32("Happy") <= 0){
               TempData["msg"] = "You Dojodachi has passed away..";
               TempData["status"] = "over";
           }
            if(HttpContext.Session.GetInt32("Fullness") >= 100 && HttpContext.Session.GetInt32("Happy") >= 100 && HttpContext.Session.GetInt32("Energy") >= 100){
                TempData["msg"] = "Congraduation You Won!";
                TempData["status"] = "won";
            
            }

           return View();
    }



        [HttpGet("Feed")]

        public IActionResult Feed(){
            if(HttpContext.Session.GetInt32("Meal") > 0){
                Random rand = new Random();
                int chance = rand.Next(0 , 4);
                if(chance == 0){
                    TempData["msg"] = "Your Dojodachi didn't like this meal";
                }
                else{
                    int increment  = rand.Next(5,10);
                    HttpContext.Session.SetInt32("Fullness", (int)HttpContext.Session.GetInt32("Fullness") + increment);
                    HttpContext.Session.SetInt32("Meal", (int)HttpContext.Session.GetInt32("Meal") - 1);
                    TempData["msg"] = $"You played with Dojodachi Fullness +{increment}, Meal -1";
                }
            }

            else
            {
                TempData["msg"] = "Your Dojodachi don't have any food";
                
            }
            return RedirectToAction("Index");


        }

        [HttpGet("playing")]
        public IActionResult Playing(){
            if(HttpContext.Session.GetInt32("Energy") > 0)
            {
                Random rand = new Random();
                int increment  = rand.Next(5,10);
                HttpContext.Session.SetInt32("Happy", (int)HttpContext.Session.GetInt32("Happy") + increment);
                HttpContext.Session.SetInt32("Energy", (int)HttpContext.Session.GetInt32("Energy") - 5);
                TempData["msg"] = $"You played with Dojodachi Happy +{increment}, Energy -5";
            }

            else
            {
                TempData["msg"] = "Your Dojodachi is too tired to play.";
               
            }
            return RedirectToAction("Index");
        }
        [HttpGet("working")]
        public IActionResult Working(){
            if(HttpContext.Session.GetInt32("Energy") > 0)
            {

            Random rand = new Random();
            int increment  = rand.Next(1,3);
            HttpContext.Session.SetInt32("Meal", (int)HttpContext.Session.GetInt32("Meal") + increment);
            HttpContext.Session.SetInt32("Energy", (int)HttpContext.Session.GetInt32("Energy") - 5);
            TempData["msg"] = $"You played with Dojodachi Meal +{increment}, Energy -5";

            }

            else
            {
                TempData["msg"] = "Your Dojodachi is too tired to work.";
            }
            return RedirectToAction("Index");

        }

        [HttpGet("sleeping")]
        public IActionResult Sleeping(){
            HttpContext.Session.SetInt32("Energy", (int)HttpContext.Session.GetInt32("Energy") + 15);
            HttpContext.Session.SetInt32("Fullness", (int)HttpContext.Session.GetInt32("Fullness") - 5);
            HttpContext.Session.SetInt32("Happy", (int)HttpContext.Session.GetInt32("Happy") - 5);
            TempData["msg"] = $"You played with Dojodachi Energy +15, Fullnes -5, Happy -5";

            return RedirectToAction("Index");

        }
        [HttpGet("restart")]
        public IActionResult Restart(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

}


}
