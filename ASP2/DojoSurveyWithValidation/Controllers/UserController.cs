using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DojoSurveyWithValidation.Models;

namespace DojoSurveyWithValidation.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]

       public IActionResult Index(){
           return View();
       }

       [HttpPost]
       [Route("result")]

       public IActionResult Submit(User user){
            if(ModelState.IsValid){
                return View("Display", user);
            }
            else{
                return View("Index");
            }
           

       }
}

}