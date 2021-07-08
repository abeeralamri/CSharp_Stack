using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private MyContext DbContext;

        public WeddingController(MyContext context)
        {
            DbContext = context;
        } 

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("uid") != null)
            {
                int id = (int)HttpContext.Session.GetInt32("uid");
                List<Wedding> ListWedding = DbContext.Weddings
                .Include(w=>w.Creator)
                .Include(w=>w.UserWedding)
                .ThenInclude(u=>u.User)
                .ToList();
                ViewBag.UserID = id;
            
            return View("Dashboard", ListWedding);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        [HttpGet("AddWedding")]
        public ViewResult AddWedding()
        {
            return View();
        }

        [HttpPost("new")]
          public IActionResult Create(Wedding newWedding)
        {
           if(ModelState.IsValid)
            {
                if(newWedding.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Date must be in future");
                    return View("AddWedding");
                }
                else
                {
                    newWedding.UserId = (int) HttpContext.Session.GetInt32("uid");
                    DbContext.Weddings.Add(newWedding);
                    DbContext.SaveChanges();
                    return Redirect($"WeddingDetails/{newWedding.WeddingId}");
                }
            }
            else
            {
                return View("AddWedding");
            }
        }

        [HttpGet("WeddingDetails/{weddingID}")]
        public IActionResult WeddingDetails(int weddingID)
        {
            int id = (int)HttpContext.Session.GetInt32("uid");
            ViewBag.UserID = id;
            Wedding ThisWedding = DbContext.Weddings
            .Include(w=>w.UserWedding)
            .ThenInclude(u=>u.User)
            .FirstOrDefault(w=>w.WeddingId == weddingID);
            return View("WeddingDetails", ThisWedding);
        }

        [HttpGet("delete/{weddingID}")]
        public IActionResult DeleteWedding(int weddingID)
        {
            Wedding ThisWedding = DbContext.Weddings.SingleOrDefault(w=>w.WeddingId == weddingID);
            DbContext.Weddings.Remove(ThisWedding);
            DbContext.SaveChanges();
            return RedirectToAction("dashboard");
        }


        [HttpGet("join/{weddingID}")]
        public IActionResult Join(int weddingID)
        {
            UserWedding ThisJoin = new UserWedding();
            ThisJoin.UserId = (int)HttpContext.Session.GetInt32("uid");
            ThisJoin.WeddingId = weddingID;
            DbContext.UserWeddings.Add(ThisJoin);
            DbContext.SaveChanges();
            return RedirectToAction("dashboard");

        }

        [HttpGet("unjoin/{weddingID}")]
        public IActionResult Unjoin(int weddingID)
        {
        
            UserWedding ThisJoin = DbContext.UserWeddings.FirstOrDefault(w=>w.WeddingId == weddingID && w.UserId == (int)HttpContext.Session.GetInt32("uid"));
            DbContext.UserWeddings.Remove(ThisJoin);
            DbContext.SaveChanges();
            return RedirectToAction("dashboard");
        }
        
        

        [HttpGet("edit/{weddingID}")]
        public IActionResult EditWedding(int weddingID)
        {
            Wedding thisWedding = DbContext.Weddings.FirstOrDefault(w=>w.WeddingId == weddingID);
            return View(thisWedding);
        }

        [HttpPost("editW/{weddingID}")]
        public IActionResult EditProcess(int weddingID, Wedding EditW)
        {
            Wedding thisWedding = DbContext.Weddings.FirstOrDefault(w=>w.WeddingId == weddingID);

            if(ModelState.IsValid)
            {
                if(EditW.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Date must be in future");
                    return View("EditWedding");
                }
                else{
                    thisWedding.Wedder1 = EditW.Wedder1;
                    thisWedding.Wedder2 = EditW.Wedder2;
                    thisWedding.Date = EditW.Date;
                    thisWedding.WeddingAddress = EditW.WeddingAddress;
                    thisWedding.UpdatedAt = DateTime.Now;
                    DbContext.SaveChanges();
                    return Redirect($"/WeddingDetails/{thisWedding.WeddingId}");
                }
            }
            else
            {
                return View("EditWedding");
            }

        }
        [HttpGet("logout")]
        public RedirectToActionResult Lougout(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "User");
        }
    }
}