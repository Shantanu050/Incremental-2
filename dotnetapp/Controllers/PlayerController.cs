using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Index()
        {
            var data=_context.Players.Include("Team").ToList();
            return View(data);
        }
        
       [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
                _context.Players.Add(player);
                _context.SaveChanges();
                return RedirectToAction("Index");
               // return View();
        }     
        
    
        public IActionResult Edit(int id)
        {
            var data=_context.Players.Find(id);
            return View(data);
        }
        
        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if(ModelState.IsValid)
            {
            Player editedPlayer=_context.Players.Find(player.Id);
            editedPlayer.Name=player.Name;
            editedPlayer.Category=player.Category;
            editedPlayer.BiddingAmount=player.BiddingAmount;
           // editedPlayer.TeamId=player.TeamId;
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();

            
        }
        
        public IActionResult DeleteConfirmed(int id)
        {
             var data=_context.Players.Find(id);
             return View(data);
        }
        // [HttpPost]
        // public IActionResult DeleteConfirmed(Player player)
        // {
        //     Player deletedPlayer=_context.Players.Find(player.Id);
        //     _context.Players.Remove(deletedPlayer);
        //     _context.SaveChanges();
        //     return RedirectToAction("Index");

        // }
        
        public IActionResult Delete(int id)
        {
             var data=_context.Players.Find(id);
             return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Player player)
        {
            Player deletedPlayer=_context.Players.Find(player.Id);
            _context.Players.Remove(deletedPlayer);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult FindPlayer()
        {
            TempData["req"]=0;
            return View();
        }
        [HttpPost]
        public IActionResult FindPlayer(Player p)
        {
            TempData["req"]=1;
            var data=_context.Players.Find(p.Id);
            return View(data);
        }
    }
}

