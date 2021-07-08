using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WeddingPlanner.Controllers
{
    public class UserController : Controller
    {
        private MyContext DbContext;

        public UserController(MyContext context)
        {
            DbContext = context;
        } 

        [HttpGet("")]

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost("Register")]

        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(DbContext.Users.Any(e=>e.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email is already exist!");
                    return View("Index");
                }

                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    DbContext.Users.Add(newUser);
                    DbContext.SaveChanges();
                    HttpContext.Session.SetInt32("uid", newUser.UserId);
                    return RedirectToAction("dashboard", "Wedding");
                }

               
            }
             return View("Index");
        }


        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
           if (ModelState.IsValid)
            {
                // Find user in DB
                User user = DbContext.Users.FirstOrDefault( u => u.Email == login.LoginEmail);
                if (user == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Login ");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<Login> Hasher = new PasswordHasher<Login>();

                    var result = Hasher.VerifyHashedPassword(login, user.Password, login.LoginPassword);

                    if (result == 0)
                    {
                        ModelState.AddModelError("LoginEmail", "Invalid Login ");
                        return View("Index");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("uid", user.UserId);
                        return RedirectToAction("dashboard", "Wedding");
                    }
                }
                
            }
            else 
            {
                return View("Index");
            }
        }        

        

       

        

    }
}