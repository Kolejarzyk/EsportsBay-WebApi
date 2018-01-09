using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Model
{
    public class Stream : BaseEntity
    {

        public string Name { get; set; }
        public string Url { get; set; }
    }
}
