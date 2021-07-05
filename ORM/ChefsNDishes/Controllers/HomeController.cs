using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefsNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;
        public HomeController(MyContext context)
        {
            DbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChef = DbContext.Chefs.Include(C => C.CreatedDish).ToList();
            ViewBag.ListChef = AllChef;
            return View();
        }

        [HttpGet("new")]
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                var age = DateTime.Now.Year - newChef.BirthDate.Year;
                if(age < 18)
                {
                    ModelState.AddModelError("BirthDate", "Age should be at least 18");
                    return View("AddChef");
                }
                DbContext.Add(newChef);
                DbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View("AddChef");
            }
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDish = DbContext.Dishes.Include(d => d.Creator).ToList();
            ViewBag.ListDishes = AllDish;
            return View();
        }
        
        [HttpGet("new/dishes")]
        public IActionResult AddDish()
        {
            List<Chef> AllChefs = DbContext.Chefs.ToList();
            ViewBag.ListChefs = AllChefs;
            return View();
        }

        [HttpPost("createDish")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                DbContext.Add(newDish);
                DbContext.SaveChanges();
                return RedirectToAction("dishes");

            }
            else
            {
                return View("AddDish");
            }
        }

    }
}
