using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Model
{
    public class Tournament : BaseEntity
    {
        public DateTime StartOfEvent { get; set; }

        public DateTime EndOfEvent { get; set; }

        public string Game { get; set; }

        public int NumberOfParticipants { get; set; }

        public List<Team> ListOfTeams { get; set; }
    }
}
