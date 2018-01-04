using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Model
{
    public class Match
    {
        public string Description { get; set; }
        public int ScoreTeam1 { get; set; }

        public int ScoreTeam2 { get; set; }
        public DateTime StartDate { get; set; }

        public Team Team1 { get; set; }

        public Team Team2 { get; set; }
    }
}
