using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public interface IMatchRepository : IRepository<Match>
    {

       void SearchByTeam(string teamName);
        void SearchByTeam(string teamName, string teamName2);
    }
}
