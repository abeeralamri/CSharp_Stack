using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context){
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index(){
            List<Dish> AllDishes = _context.Dishes.ToList();
            ViewBag.listDishes = AllDishes;
            return View();
        }

       

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View("Create");

        }
        [HttpPost("new")]
        public IActionResult New(Dish newDish)
        {
            
            if(ModelState.IsValid){
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                return View("Create");
            }
        }

        [HttpGet("info/{id}")]
        public IActionResult Details(int id)
        {
            Dish OneDish = _context.Dishes.FirstOrDefault(d => d.DishesId == id);
            return View("Detail", OneDish);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Update(int id)
        {

            Dish OneDish = _context.Dishes.FirstOrDefault(d => d.DishesId == id);
            return View("Update", OneDish);

        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateDishes(Dish update, int id)
        {
            
            if(ModelState.IsValid){
                Dish UpdateDish = _context.Dishes.FirstOrDefault(d => d.DishesId == id);
                UpdateDish.Name = update.Name;
                UpdateDish.Chef = update.Chef;
                UpdateDish.Calorie = update.Calorie;
                UpdateDish.Tastiness = update.Tastiness;
                UpdateDish.Desc = update.Desc;
                UpdateDish.UpdateAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                update.DishesId = id;
                return View("Update", update);
            }
        }

        [HttpGet("delete/{id}")]
        public IActionResult  Delete(int id){
            Dish OneDish = _context.Dishes.SingleOrDefault(d => d.DishesId == id);
            _context.Dishes.Remove(OneDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
