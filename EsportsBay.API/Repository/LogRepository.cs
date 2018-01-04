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
        public void SearchByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
