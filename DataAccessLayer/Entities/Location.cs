using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Location
    {
        public string LocationId { get; set; }//PK
        public string LocationName { get; set; }
        public List<Stops>? Stops { get; set; }
    }
}
