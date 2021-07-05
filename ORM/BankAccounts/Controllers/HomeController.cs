using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;

        public HomeController(MyContext context)
        {
            DbContext = context;
        }

        [HttpGet("")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("")]
        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid)
            {
               if(DbContext.Users.Any(u => u.Email == newUser.Email))
               {
               ModelState.AddModelError("Email", "Email is already exist");
               return View("Register");
               }
           
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            DbContext.Add(newUser);
            DbContext.SaveChanges();

            HttpContext.Session.SetInt32("userId", newUser.UserId);
            return RedirectToAction("Account", new{newUser.UserId});
        } 
        return View("Register");
        
        }
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("login")]
        public IActionResult LoginP(Login login)
        {
           if(ModelState.IsValid)
           {
               User Logged = DbContext.Users.FirstOrDefault(u => u.Email == login.Email);
               if(Logged != null)
               {
                   PasswordHasher<Login> Hasher =  new PasswordHasher<Login>();
                   if(Hasher.VerifyHashedPassword(login, Logged.Password, login.Password) != 0)
                   {
                       HttpContext.Session.SetInt32("userId", Logged.UserId);
                       return RedirectToAction("Account", new {Logged.UserId});
                   }
               }
               ModelState.AddModelError("Email", "Invalid login");
               return View("Login");
           } 

           return View("Login");
        }


        [HttpGet("account/{userId}")]
        public IActionResult Account()
        {
            if(HttpContext.Session.Get("userId") == null)
            {
                return View("Register");
            }
            ViewBag.User = DbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId"));
            ViewBag.Trans = DbContext.Transactions.Include(trans => trans.UserAccount)
            .Where(u=>u.UserId == HttpContext.Session.GetInt32("userId"));
            return View("Account");
        }

        [HttpPost("account/{userId}/trans")]
        public IActionResult Transaction(Transaction newTrans)
        {
            if(HttpContext.Session.Get("userId") == null)
            {
                return RedirectToAction("Register");
            }

            User user = DbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId"));
            ViewBag.User = user;
            ViewBag.Trans = DbContext.Transactions.Include(trans => trans.UserAccount)
             .Where(u=>u.UserId == HttpContext.Session.GetInt32("userId"));
           

            if(ModelState.IsValid)
            {
                if(user.Balance + newTrans.Amount < 0)
                {
                    ModelState.AddModelError("Amount", "You do not have enough balance");
                    return View("Account");
                }
                
                DbContext.Add(newTrans);
                user.Balance += newTrans.Amount;
                DbContext.SaveChanges();
                return RedirectToAction("Account");
            }
            return View("Account");

        }

        [HttpGet("logout")]

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Register");
        }

        

}

}