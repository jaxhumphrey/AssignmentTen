using AssignmentTen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AssignmentTen.Models.ViewModels;


namespace AssignmentTen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        //bowlers per page
        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        
        public IActionResult Index(int page = 1)
        {
        
            //query written in LINK
            return View(new BowlingTeamViewModel
            {
                Bowlers = context.Bowlers
                .OrderBy(p => p.BowlerFirstName)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)

                ,

                //create new PagingInfo Object
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalNumItems = context.Bowlers.Count()
                }
        });
      }

        
        public IActionResult GetTeam(string teamname)
        {

            ViewBag.TeamName = teamname;

            return View("Index", new BowlingTeamViewModel
            {
                Bowlers = context.Bowlers
                .Where(x => x.Team.TeamName == teamname)

                ,

                //create new PagingInfo Object
                PagingInfo = new PagingInfo
                {
                    CurrentPage = 1,
                    ItemsPerPage = PageSize,
                    TotalNumItems = context.Bowlers.Where(x => x.Team.TeamName == teamname).Count()
                }
            });
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
