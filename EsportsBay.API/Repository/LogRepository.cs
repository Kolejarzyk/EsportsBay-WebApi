using EsportsBay.API.Data;
using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(DataContext context) : base(context)
        {
        }
       
        public IEnumerable<Log> SearchByDate(DateTime date)
        {
            return _context.Set<Log>().Where(x => x.Date.Equals(date)).OrderBy(o => o.Date).ToList();
        }
    }
}
