using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.DataContracts
{
    public class LogDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }

        public string Title { get; set; }
    }
}
