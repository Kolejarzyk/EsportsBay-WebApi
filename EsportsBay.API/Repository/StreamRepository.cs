using EsportsBay.API.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public class StreamRepository : Repository<Stream> , IStreamRepository
    {
        public StreamRepository(DataContext context) : base(context)
        {

        }
    }
}
