using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Stops
    {
        public int StopId { get; set; }//PK
        public int StopOfferId { get; set; }//FK
        public int LocationId { get; set; }//FK
        public int StopNumber { get; set; }

        public OfferRide OfferRide;

        public Location Location;
    }
}
