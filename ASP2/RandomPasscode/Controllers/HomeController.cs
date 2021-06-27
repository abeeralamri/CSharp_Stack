using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [Route("")]
        public ViewResult Index()
       {
           
          if(HttpContext.Session.GetInt32("Count") == null){
              HttpContext.Session.SetInt32("Count", 0);
          }
           
           ViewBag.Count = HttpContext.Session.GetInt32("Count");
           ViewBag.RandomCode = HttpContext.Session.GetString("RandomCode");
          
           return View();
    }

    [HttpGet]
    [Route("generate")]
    public IActionResult Generate(){
        Random rand = new Random();
        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string RandCode = "";
        for (int i = 0; i < 14; i++)
        {
            RandCode += Alphabet[rand.Next(Alphabet.Length)];
        }
        HttpContext.Session.SetString("RandomCode", RandCode);
        HttpContext.Session.SetInt32("Count", (int)HttpContext.Session.GetInt32("Count") + 1);
        return RedirectToAction("Index");
    }
}


}