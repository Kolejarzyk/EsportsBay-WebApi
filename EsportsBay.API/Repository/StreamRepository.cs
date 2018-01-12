using EsportsBay.API.Data;
using EsportsBay.API.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public class StreamRepository : Repository<Stream> , IStreamRepository
    {
        public StreamRepository(DataContext context) : base(context)
        {

        }

        public IEnumerable<Stream> SearchByGameStream(string game)
        {
            yield return _context.Set<Stream>().Find(game);
        }

     
    }
}
