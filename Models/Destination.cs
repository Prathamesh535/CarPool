using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Destination
    {
        public int? StopId { get; set; }
        public string StopName { get; set; }    
        public string? StopOfferId { get; set; }
        public int? StopNumber { get; set; }
    }
}
