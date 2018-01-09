using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Model
{
    public class Log : BaseEntity
    {
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public string Title { get; set; }


    }
}
