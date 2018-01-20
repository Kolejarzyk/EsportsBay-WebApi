using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.DataContracts
{
    public class StreamDto
    {
        public int Id { get; set; }
        public string Game { get; set; }
        public string DisplayName { get; set; }

        public string Language { get; set; }

        public string ImgUrl { get; set; }
        public string Url { get; set; }
    }
}
