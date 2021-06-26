using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;
namespace ViewModelFun.Controllers
{
    public class UserController : Controller
    {
          List<User> names = new List<User>{
                     new User(){
                        firstName = "Sally",},
                        new User(){
                        firstName = "Moose",
                        lastName = "Philips"},
                        new User(){
                        firstName = "Sarah",},
                        new User(){
                        firstName = "Jerry",},
                        new User(){
                        firstName = "Rane",
                        lastName = "Ricky"},
                        
                };
        [HttpGet]
        [Route("")]

        public IActionResult Index(){
           
            string message = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. ";
            return View("Index", message);
        }

        [HttpGet]
        [Route("numbers")]
           public IActionResult Numbers(){
           
            int [] number =  {1,3,4,7,8,1,19};
       
            return View(number);
        }


        [HttpGet]
        [Route("users")]
            public IActionResult Users()
            {
                  
                return View(names);
            }
        [HttpGet]
        [Route("user")]
            public IActionResult OneUser(){
                var random =  new Random();
                var name = names[random.Next(names.Count)];
                return View(name);


            }
        

}

}
