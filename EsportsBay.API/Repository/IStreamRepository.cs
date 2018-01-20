using EsportsBay.API.Model;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public interface IStreamRepository : IRepository<Stream>
    {
        IEnumerable<Stream> GetStreamByGame(string game);

        IEnumerable<Stream> GetStreamByLanguage(string language);


    }
}
