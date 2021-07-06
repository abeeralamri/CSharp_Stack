using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            //1
            ViewBag.WomenLeagues = _context.Leagues
                .Where(women => women.Name.Contains("Women"))
                .ToList();
            //2
            ViewBag.Hockey = _context.Leagues
                .Where(s => s.Name.Contains("Hockey"))
                .ToList();

            //3
            ViewBag.NotFootball = _context.Leagues
                .Where(f => !f.Name.Contains("Football"))
                .ToList();
            //4

            ViewBag.conferences = _context.Leagues
                .Where(c => c.Name.Contains("Conference"))
                .ToList();
            //5
            ViewBag.Athletics = _context.Leagues
                .Where(a => a.Name.Contains("Athletic"))
                .ToList();
            //6
            ViewBag.Dallas = _context.Teams
                .Where(d => d.Location.Contains("Dallas"))
                .ToList();
            //7
            ViewBag.Raptors = _context.Teams
                .Where(r => r.TeamName.Contains("Raptors"))
                .ToList();
            //8
            ViewBag.City = _context.Teams
                .Where(c => c.Location.Contains("City"))
                .ToList();
            //9
            ViewBag.ContainT = _context.Teams
                .Where(t => t.TeamName.Contains("T"))
                .ToList();
            //10
            ViewBag.Order = _context.Teams
                .OrderBy(order => order.Location)
                .ToList();

            //11
            ViewBag.OrderByName = _context.Teams
                .OrderByDescending(order => order.TeamName)
                .ToList();
            //12
            ViewBag.LName = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .ToList();

            //13
            ViewBag.FName = _context.Players
                .Where(p => p.FirstName.Contains("Joshua"))
                .ToList();

            //14
            ViewBag.LNameExcept = _context.Players
                .Where(p => p.LastName.Contains("Cooper"))
                .Where(p => !p.FirstName.Contains("Joshua"))
                .ToList();
            //15
            ViewBag.OR = _context.Players
                .Where(p => p.FirstName.Contains("Alexander") || p.FirstName.Contains("Wyatt"))
                .ToList();


            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            //1
            ViewBag.Allteam = _context.Teams
            .Include(t => t.CurrLeague)
            .Where(t => t.CurrLeague.Name.Contains("Atlantic Soccer Conference"))
            .ToList();

            //2
            ViewBag.CurrPlayerBoston = _context.Players
            .Include(c => c.CurrentTeam)
            .Where(c => c.CurrentTeam.TeamName.Contains("Penguins") && c.CurrentTeam.Location.Contains("Boston"))
            .ToList();

            //3
            ViewBag.CurrPlayerBaseball = _context.Teams
            .Include(c => c.CurrLeague)
            .Where(c => c.CurrLeague.Name.Contains("International Collegiate Baseball Conference"))
            .ToList();

            //4
            ViewBag.CurrPlayerAmerican = _context.Players
            .Include(s => s.CurrentTeam)
            .Where(s => s.CurrentTeam.CurrLeague.Name.Contains("American Conference of Amateur Football"))
            .Where(s => s.LastName.Contains("Lopez"))
            .ToList();

            //5
            ViewBag.Allfotball = _context.Players
            .Include(l => l.CurrentTeam)
            .Where(l => l.CurrentTeam.CurrLeague.Sport.Contains("Football"))
            .ToList();
           

            //6
            ViewBag.AllteamSophia = _context.Players
            .Include(s => s.CurrentTeam.CurrentPlayers)
            .Where(s => s.FirstName.Contains("Sophia"))
            .ToList();

            //7
            ViewBag.AllteamLSophia = _context.Players
            .Include(p => p.CurrentTeam.CurrLeague)
            .Where(s => s.FirstName.Contains("Sophia"))
            .ToList();

            //8
             ViewBag.flores = _context.Players
            .Include(f=>f.CurrentTeam)
            .Where(f=>f.LastName.Contains("Flores") && !f.CurrentTeam.TeamName.Contains("Washington Roughriders"))
            .ToList();

            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}