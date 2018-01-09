using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.DataContracts
{
    public class TournamentDto
    {
        public int Id { get; set; }

        public string StartOfEvent { get; set; }

        public string EndOfEvent { get; set; }

        public string Game { get; set; }

        public int NumberOfParticipants { get; set; }

        public string ListOfTeams { get; set; }
    }
}
