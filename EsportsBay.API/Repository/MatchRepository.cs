using EsportsBay.API.Data;
using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public class MatchRepository : Repository<Match>, IMatchRepository
    {
        public MatchRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Match> SearchByTeam(string teamName)
        {
            return _context.Set<Match>().Where(x => x.Team1.Equals(teamName) || x.Team2.Equals(teamName))
            .OrderBy(o => o.StartDate).ToList();
        }

        
    }
}
