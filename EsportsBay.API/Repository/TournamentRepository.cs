using EsportsBay.API.Data;
using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public class TournamentRepository : Repository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(DataContext _context) : base(_context)
        {
        }
    }
}
