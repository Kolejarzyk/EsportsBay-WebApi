using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public interface ILogRepository : IRepository<Log>
    {
        IEnumerable<Log> SearchByDate(DateTime date);
    }
}
