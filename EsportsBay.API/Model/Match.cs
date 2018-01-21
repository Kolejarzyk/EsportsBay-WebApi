using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Model
{
    public class Match : BaseEntity
    {
        public string Description { get; set; }
        public int ScoreTeam1 { get; set; }

        public int ScoreTeam2 { get; set; }
        public DateTime StartDate { get; set; }

        public string Team1 { get; set; }

        public string Team2 { get; set; }
    }
}
