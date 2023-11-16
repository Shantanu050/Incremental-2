using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult DisplayTeams()
        {
            var data=_context.Teams.ToList();
            return View(data);
        }

        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team team)
        {
            _context.Teams.Add(team);
            return RedirectToAction("DisplayTeams");
        }
    }
}