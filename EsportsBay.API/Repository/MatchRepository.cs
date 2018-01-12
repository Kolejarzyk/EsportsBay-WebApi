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

        public void SearchByTeam(string teamName)
        {
            throw new NotImplementedException();
        }

        public void SearchByTeam(string teamName, string teamName2)
        {
            throw new NotImplementedException();
        }
    }
}
