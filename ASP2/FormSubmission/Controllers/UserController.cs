using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    
       public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index (){
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Sumbit(User create){
            if(ModelState.IsValid){
                return View("Sumbit");
            }
            else{
                return View("Index");
            }
        }
    }
}
    
    
