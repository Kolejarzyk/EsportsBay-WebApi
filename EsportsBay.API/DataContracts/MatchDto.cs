using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.DataContracts
{
    public class MatchDto
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public string ScoreTeam1 { get; set; }

        public string ScoreTeam2 { get; set; }
        public string StartDate { get; set; }

        public string Team1 { get; set; }

        public string Team2 { get; set; }
    }
}
