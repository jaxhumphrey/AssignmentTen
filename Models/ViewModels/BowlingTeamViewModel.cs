using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentTen.Models.ViewModels
{
    public class BowlingTeamViewModel
    {
        //contains bowlers themselves, and also paging info
        public IEnumerable<Bowlers> Bowlers { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
