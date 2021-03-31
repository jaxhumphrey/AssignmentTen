using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentTen.Models;

namespace AssignmentTen.Components
{
    public class NavMenuViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;

        public NavMenuViewComponent(BowlingLeagueContext ctx)
        {
            //set context equal to bowling league context
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            var NavBarList = context.Bowlers
                                 .Select(x => x.Team)
                                 .Distinct()
                                 .OrderBy(x => x);

            return View(NavBarList);
        }

    }
}
