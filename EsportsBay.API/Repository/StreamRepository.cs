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

        public IEnumerable<Stream> GetStreamByGame(string game)
        {
            return _context.Set<Stream>().Where(x => x.Game.Equals(game)).OrderBy(o => o.DisplayName).ToList();
        }

        public IEnumerable<Stream> GetStreamByLanguage(string language)
        {
            return _context.Set<Stream>().Where(x => x.Language.Equals(language)).OrderBy(o => o.DisplayName).ToList();
        }

    }
}
