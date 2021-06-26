using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithModel.Models;

namespace DojoSurveyWithModel.Controllers
{
    public class SurveyController : Controller
    {
       [HttpGet]
       [Route("")]

       public IActionResult Index(){
           return View();
       }

       [HttpPost]
       [Route("result")]

       public IActionResult Result(Survey survey){
            
           return View("Display", survey);

       }
    }
}
