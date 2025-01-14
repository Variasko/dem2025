using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorMaster
{
    public class OrderView
    {
        public string partneer { get; set; }
        public DateTime date { get; set; }
        public string product { get; set; }
        public int amount { get; set; }
        public decimal caost { get; set; }
        public decimal sum { get; set; }
    }
}
