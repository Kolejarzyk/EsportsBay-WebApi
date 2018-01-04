using EsportsBay.API.Data;
using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(DataContext _context) : base(_context)
        {
        }
    }
}
